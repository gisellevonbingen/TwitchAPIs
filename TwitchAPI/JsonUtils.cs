using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPI
{
    public static class JsonUtils
    {
        public static IEnumerable<T> GetArrayValues<T>(this JToken value, object key)
        {
            if (value == null)
            {
                return null;
            }

            if (value[key] is JArray array)
            {
                return array.Values<T>();
            }

            return null;
        }

    }

}
