using Giselle.Commons.Web;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs
{
    public static class WebExplorerExtenstions
    {
        public static JToken ReadAsJSON(this WebResponse session)
        {
            var content = session.ReadAsString();
            var jToken = JObject.Parse(content);

            return jToken;
        }

    }

}
