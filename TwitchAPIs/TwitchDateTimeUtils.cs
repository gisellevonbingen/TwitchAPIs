using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs
{
    public static class TwitchDateTimeUtils
    {
        public static string Format { get; } = "yyyy-MM-dd'T'HH:mm:ss'Z'";

        public static DateTime? ToDatetime(string s)
        {
            return DateTime.TryParseExact(s, Format, null, System.Globalization.DateTimeStyles.None, out var result) ? result : new DateTime?();
        }

        public static string ToString(DateTime? value)
        {
            return value?.ToString(Format);
        }

    }

}
