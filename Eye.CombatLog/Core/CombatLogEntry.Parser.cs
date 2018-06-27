using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Internal;
using Sprache;
using Eye.CombatLog.Objects;

namespace Eye.CombatLog.Core
{
    public partial class CombatLogEntry
    {
        public static CombatLogEntry[] Parse(string data) //TODO: Переписать парсер
        {
            var arr = Regex.Split(data, "[{}]")
                .Select(str => str.Trim())
                .Where(str => str != string.Empty)
                .Select(str => Regex.Replace(str, "[\r\t ]", string.Empty))
                .Select(str => str.Split('\r', '\n'))
                .Select(fields => fields.Select(field => new KeyValuePair<string, string>(field.Split(':')[0], field.Split(':')[1])).ToList())
                .Select(fields =>
                {
                    var type = (CombatLogEntryTypes)int.Parse(fields.FirstOrDefault(field => field.Key == "type").Value);

                    return CombatLogEntryFactory.Create(type, fields);
                });

            var array = arr.ToArray();

            return array;
        }
    }
}
