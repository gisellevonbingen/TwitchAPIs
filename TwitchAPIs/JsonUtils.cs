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
        public static Dictionary<K, V> ReadMap<K, V>(this JToken value, string propertyName, Func<string, JToken, KeyValuePair<K, V>> func)
        {
            return value.ReadIfExist(propertyName, t => ReadMap(t, func));
        }

        public static Dictionary<K, V> ReadMap<K, V>(this JToken value, Func<string, JToken, KeyValuePair<K, V>> func)
        {
            if (value is JObject jObject)
            {
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

            return null;
        }

        public static T[] ReadArray<T>(this JToken value, string propertyName, Func<JToken, T> func)
        {
            return value.ReadIfExist(propertyName, t => ReadArray(t, func));
        }

        public static T[] ReadArray<T>(this JToken value, Func<JToken, T> func)
        {
            if (value is JArray jArray)
            {
                var array = new T[jArray.Count];

                for (int i = 0; i < jArray.Count; i++)
                {
                    var token = jArray[i];
                    array[i] = func(token);
                }

                return array;
            }

            return null;
        }

        public static T ReadIfExist<T>(this JToken value, string propertyName, Func<JToken, T> func)
        {
            if (value is JObject jObject)
            {
                if (jObject.TryGetValue(propertyName, out var jToken) == true)
                {
                    return jToken.ReadIfExist(func);
                }

            }

            return default;
        }

        public static T ReadIfExist<T>(this JToken value, Func<JToken, T> func)
        {
            if (value == null)
            {
                return default;
            }
            if (value is JValue jValue)
            {
                if (jValue.Value == null)
                {
                    return default;
                }

            }

            return func(value);
        }

        public static IEnumerable<T> ArrayValues<T>(this JToken value, string propertyName)
        {
            return value.ReadIfExist(propertyName, t => ArrayValues<T>(t));
        }

        public static IEnumerable<T> ArrayValues<T>(this JToken value)
        {
            if (value is JArray jArray)
            {
                return jArray.Values<T>();
            }

            return null;
        }

    }

}
