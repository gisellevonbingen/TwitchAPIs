using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs
{
    public static class NumberUtils
    {
        public static bool? ToBoolNullable(string s)
        {
            return bool.TryParse(s, out bool result) ? new bool?(result) : null;
        }

        public static bool ToBool(string s, bool fallback)
        {
            return bool.TryParse(s, out bool result) ? result : fallback;
        }

        public static bool ToBool(string s)
        {
            return ToBool(s, false);
        }

        public static int? ToIntNullable(string s)
        {
            return int.TryParse(s, out int result) ? new int?(result) : null;
        }

        public static int ToInt(string s, int fallback)
        {
            return int.TryParse(s, out int result) ? result : fallback;
        }

        public static int ToInt(string s)
        {
            return ToInt(s, 0);
        }

    }

}
