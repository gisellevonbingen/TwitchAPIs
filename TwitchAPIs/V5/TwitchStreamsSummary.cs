using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.V5
{
    public class TwitchStreamsSummary
    {
        public int Channels { get; set; }
        public int Viewers { get; set; }

        public TwitchStreamsSummary()
        {

        }

        public TwitchStreamsSummary(JToken jToken)
        {
            this.Channels = jToken.Value<int>("channels");
            this.Viewers = jToken.Value<int>("viewers");
        }

    }

}
