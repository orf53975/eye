using Eye.CombatLog.Objects;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Eye.Shared;

namespace Eye.CombatLog.Core
{
    public partial class CombatLogEntry : IDataEntry
    {
        public CombatLogEntryTypes Type { get; set; }
        public double Timestamp { get; set; }
        public string Token { get; set; }

        public virtual void Make() { }

        internal List<KeyValuePair<string, string>> Fields { get; set; }

        internal KeyValuePair<string, string> GetPair(string key)
        {
            var pair = Fields.FirstOrDefault(p => p.Key == key);
            return pair;
        }

        internal int GetIntField(string key)
        {
            var pair = GetPair(key);
            if (pair.Value == null) return 0;

            if (int.TryParse(pair.Value, out var intResult))
                return intResult;

            if (uint.TryParse(pair.Value, out var uIntResult))
                return (int)((uint.MaxValue - uIntResult) * -1);

            return default(int);
        }

        internal long GetLongField(string key)
        {
            var pair = GetPair(key);
            if (pair.Value == null) return 0;

            return long.Parse(pair.Value, CultureInfo.InvariantCulture);
        }

        internal double GetDoubleField(string key)
        {
            var pair = GetPair(key);
            if (pair.Value == null) return 0;

            return double.Parse(pair.Value, CultureInfo.InvariantCulture);
        }

        internal bool GetBooleanField(string key)
        {
            return GetIntField(key) == 1;
        }

        internal string GetStringField(string key)
        {
            var pair = GetPair(key);

            return pair.Value;
        }

        internal int GetFirstValue()
        {
            var valuesPair = Fields.Where(p => p.Key == "value");
            var pair = valuesPair.FirstOrDefault();

            if (int.TryParse(pair.Value, out var intResult))
                return intResult;

            if (uint.TryParse(pair.Value, out var uIntResult))
                return (int)((uint.MaxValue - uIntResult) * -1);

            return default(int);
        }

        internal int GetSecondValue()
        {
            var valuesPair = Fields.Where(p => p.Key == "value");
            var pair = valuesPair.LastOrDefault();

            if (int.TryParse(pair.Value, out var intResult))
                return intResult;

            if (uint.TryParse(pair.Value, out var uIntResult))
                return (int)((uint.MaxValue - uIntResult) * -1);

            return default(int);
        }
    }
}