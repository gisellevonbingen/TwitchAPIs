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
            return value.ReadIfExist(propertyName, t => ReadMap(t, func)) ?? new Dictionary<K, V>();
        }

        public static Dictionary<K, V> ReadMap<K, V>(this JToken value, Func<string, JToken, KeyValuePair<K, V>> func)
        {
            var map = new Dictionary<K, V>();

            if (value is JObject jObject)
            {
                foreach (var pair in jObject)
                {
                    var childKey = pair.Key;
                    var childValueToken = pair.Value;
                    var obj = func(childKey, childValueToken);

                    map[obj.Key] = obj.Value;
                }

            }

            return map;
        }

        public static T[] ReadArray<T>(this JToken value, string propertyName, Func<JToken, T> func)
        {
            return value.ReadIfExist(propertyName, t => ReadArray(t, func)) ?? new T[0];
        }

        public static T[] ReadArray<T>(this JToken value, Func<JToken, T> func)
        {
            var list = new List<T>();

            if (value is JArray jArray)
            {
                for (int i = 0; i < jArray.Count; i++)
                {
                    var token = jArray[i];
                    var v = func(token);

                    list.Add(v);
                }

            }

            return list.ToArray();
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
            else if (value is JValue jValue)
            {
                if (jValue.Value == null)
                {
                    return default;
                }

            }

            return func(value);
        }

        public static T[] ArrayValues<T>(this JToken value, string propertyName)
        {
            return value.ReadIfExist(propertyName, t => ArrayValues<T>(t)) ?? new T[0];
        }

        public static T[] ArrayValues<T>(this JToken value)
        {
            if (value is JArray jArray)
            {
                return jArray.Values<T>().ToArray();
            }

            return new T[0];
        }

    }

}
