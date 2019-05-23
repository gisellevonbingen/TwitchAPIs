using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPI
{
    public static class NumberUtils
    {
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
