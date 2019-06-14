using Giselle.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs
{
    public class QueryValues : List<QueryValue>
    {
        public static QueryValues Parse(string str)
        {
            str = StringUtils.RemovePrefix(str, HttpUtility2.QuerySeparator);
            var splits = str.Split(HttpUtility2.QueryValuesDelimiter);

            var queryValues = new QueryValues();
            var valueDelimiter = QueryValue.ValueDelimiter;

            foreach (var pair in splits)
            {
                if (string.IsNullOrWhiteSpace(pair) == false)
                {
                    var delimiterIndex = pair.IndexOf(valueDelimiter);
                    string key = null;
                    string value = null;

                    if (delimiterIndex == -1)
                    {
                        key = pair;
                    }
                    else
                    {
                        key = pair.Substring(0, delimiterIndex);
                        var valueStartIndex = delimiterIndex + valueDelimiter.Length;
                        value = pair.Substring(valueStartIndex, pair.Length - valueStartIndex);
                    }

                    queryValues.Add(new QueryValue(key, value));
                }

            }

            return queryValues;
        }

        public QueryValues()
        {

        }

        public override string ToString()
        {
            return this.ToString(true);
        }

        public string ToString(bool containsNullOrWhiteSpace)
        {
            return StringUtils.AddPrefix(string.Join(HttpUtility2.QueryValuesDelimiter, this.Where(p =>
            {
                if (containsNullOrWhiteSpace == false)
                {
                    if (string.IsNullOrWhiteSpace(p.Key) == true || string.IsNullOrWhiteSpace(p.Value) == true)
                    {
                        return false;
                    }

                }

                return true;
            })), HttpUtility2.QuerySeparator);
        }

        public void Add<T>(string key, T value)
        {
            this.Add(new QueryValue(key, string.Concat(value)));
        }

        public string Single(string key)
        {
            return this.FirstOrDefault(pair => pair.Key.Equals(key, StringComparison.OrdinalIgnoreCase)).Value;
        }

        public string[] Array(string key)
        {
            return this.Where(pair => pair.Key.Equals(key, StringComparison.OrdinalIgnoreCase)).Select(pair => pair.Value).ToArray();
        }

    }

}
