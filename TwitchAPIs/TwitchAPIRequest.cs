using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Giselle.Commons.Net.Http;

namespace TwitchAPIs
{
    public class TwitchAPIRequest
    {
        public APIVersion? Version { get; set; }
        public string BaseUrl { get; set; }
        public string Path { get; set; }
        public QueryValues QueryValues { get; }
        public string Method { get; set; }
        public object PostData { get; set; }
        public string ContentType { get; set; }

        public TwitchAPIRequest()
        {
            this.QueryValues = new QueryValues();
        }

    }

}
