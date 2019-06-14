using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs
{
    public static class JsonUtils
    {
        public static Dictionary<K, V> ReadMap<K, V>(this JToken value, object key, Func<string, JToken, KeyValuePair<K, V>> func)
        {
            var jObject = value[key] as JObject;

            if (jObject == null)
            {
                return null;
            }


            var map = new Dictionary<K, V>();

            foreach (var pair in jObject)
            {
                var childKey = pair.Key;
                var childValueToken = pair.Value;
                var obj = func(childKey, childValueToken);

                map[obj.Key] = obj.Value;
            }

            return map;
        }

        public static T[] ReadArray<T>(this JToken value, object key, Func<JToken, T> func)
        {
            var jArray = value[key] as JArray;

            if (jArray == null)
            {
                return null;
            }

            var array = new T[jArray.Count];

            for (int i = 0; i < jArray.Count; i++)
            {
                var token = jArray[i];
                array[i] = func(token);
            }

            return array;
        }

        public static T ReadIfExist<T>(this JToken value, object key, Func<JToken, T> func)
        {
            var token = value[key];

            if (token != null)
            {
                return func(token);
            }

            return default(T);
        }

        public static IEnumerable<T> ArrayValues<T>(this JToken value, object key)
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
