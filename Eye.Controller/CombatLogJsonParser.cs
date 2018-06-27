using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using Eye.CombatLog.Core;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;

namespace Eye.Controller
{
    public static class CombatLogJsonParser
    {
        private static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters = {
                new IsoDateTimeConverter {DateTimeStyles = DateTimeStyles.AssumeUniversal},
                new EntryConverter()
            }
        };

        public static CombatLogEntry ParseStream(Stream stream)
        {
            using (var steamReader = new StreamReader(stream))
            {
                return ParseString(steamReader.ReadToEnd());
            }
        }

        public static CombatLogEntry ParseString(string json)
        {
            return JsonConvert.DeserializeObject<CombatLogEntry>(json, Settings);
        }

        public class EntryConverter : JsonCreationConverter<CombatLogEntry>
        {
            protected override CombatLogEntry Create(Type objectType, JObject jObject)
            {
                var type = (CombatLogEntryTypes)jObject["Type"].Value<int>();

                return CombatLogEntryFactory.Create(type);
            }
        }

        public abstract class JsonCreationConverter<T> : JsonConverter
        {
            public override bool CanWrite { get; } = false;
            protected abstract T Create(Type objectType, JObject jObject);

            public override bool CanConvert(Type objectType)
            {
                return typeof(T).IsAssignableFrom(objectType);
            }

            public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
                JsonSerializer serializer)
            {
                var jObject = JObject.Load(reader);

                var target = Create(objectType, jObject);
                serializer.Populate(jObject.CreateReader(), target);

                return target;
            }

            public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
            {
                serializer.Serialize(writer, value);
            }
        }
    }
}