using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.Test
{
    public static class EnumUtils
    {
        public static T[] GetValues<T>() where T : Enum
        {
            return Enum.GetValues(typeof(T)) as T[];
        }

        public static T?[] GetNullableValues<T>() where T : struct, Enum
        {
            return GetValues<T>().Select(v => new T?(v)).ToArray();
        }

    }

}
