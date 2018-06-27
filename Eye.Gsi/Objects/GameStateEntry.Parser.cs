using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;

namespace Eye.Gsi.Objects
{
    public partial class GameStateEntry
    {
        private static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters = {
                new IsoDateTimeConverter {DateTimeStyles = DateTimeStyles.AssumeUniversal},
                new ItemsConverter()
            }
        };

        public static GameStateEntry FromStream(Stream stream)
        {
            using (var steamReader = new StreamReader(stream))
                return FromString(steamReader.ReadToEnd());
        }

        public static GameStateEntry FromString(string json)
        {
            return JsonConvert.DeserializeObject<GameStateEntry>(json, Settings);
        }
    }

    public class ItemsConverter : JsonCreationConverter<Items.Item>
    {
        protected override Items.Item Create(Type objectType, JObject jObject)
        {
            try
            {
                var name = jObject["name"].Value<string>();
                var type = objectType;

                if (Items.ItemLinks.ContainsKey(name))
                    type = Items.ItemLinks[name];

                var item = (Items.Item) Activator.CreateInstance(type);

                return item;
            }
            catch
            {
                return new Items.Item();
            }
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