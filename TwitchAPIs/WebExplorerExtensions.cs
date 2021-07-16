using Giselle.Commons.Net;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs
{
    public static class WebExplorerExtensions
    {
        public static JToken ReadAsJson(this HttpWebResponse session)
        {
            var content = session.ReadAsString();
            var jToken = JToken.Parse(content);

            return jToken;
        }

    }

}
