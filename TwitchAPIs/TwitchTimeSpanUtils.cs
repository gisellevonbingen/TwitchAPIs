using Giselle.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TwitchAPIs
{
    public static class TwitchTimeSpanUtils
    {
        public static string HoursGroup { get; } = "h";
        public static string MinutesGroup { get; } = "m";
        public static string SecondsGroup { get; } = "s";

        public static string Pattern { get; } = $"((?<{HoursGroup}>.*)h)?((?<{MinutesGroup}>.*)m)?((?<{SecondsGroup}>.*)s)";
        public static string Format { get; } = "hh'h'mm'm'ss's'";

        public static TimeSpan? ToTimeSpanNullable(string s)
        {
            try
            {
                return ToTimeSpan(s);
            }
            catch (Exception)
            {
                return null;
            }

        }

        public static TimeSpan ToTimeSpan(string s)
        {
            var match = Regex.Match(s, Pattern);
            var hours = NumberUtils.ToInt(match.Groups[HoursGroup].Value);
            var minutes = NumberUtils.ToInt(match.Groups[MinutesGroup].Value);
            var seconds = NumberUtils.ToInt(match.Groups[SecondsGroup].Value);
            return new TimeSpan(hours, minutes, seconds);
        }

        public static string ToString(TimeSpan? value)
        {
            return value?.ToString(Format);
        }

    }

}
