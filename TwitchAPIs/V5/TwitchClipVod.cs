using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.V5
{
    public class TwitchClipVod
    {
        public string Id { get; set; }
        public string Url { get; set; }

        public TwitchClipVod()
        {

        }

        public TwitchClipVod(JToken jToken)
        {
            this.Id = jToken.ReadIfExist("id", t => t.Value<string>());
            this.Url = jToken.ReadIfExist("url", t => t.Value<string>());
        }

    }

}
