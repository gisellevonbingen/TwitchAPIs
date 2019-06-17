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

        public static DateTime Parse(string s)
        {
            return DateTime.ParseExact(s, Format, null);
        }

        public static string ToString(DateTime dateTime)
        {
            return dateTime.ToString(Format);
        }

    }

}
