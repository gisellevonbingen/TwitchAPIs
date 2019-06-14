using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs
{
    public class TwitchAPIRequestParameter
    {
        public APIVersion? Version { get; set; }
        public string BaseURL { get; set; }
        public string Path { get; set; }
        public List<QueryValue> QueryValues { get; }
        public string Method { get; set; }

        public TwitchAPIRequestParameter()
        {
            this.QueryValues = new List<QueryValue>();
        }

        public void AddQueryValue(string key, string value)
        {
            this.QueryValues.Add(new QueryValue(key, value));
        }

    }

}
