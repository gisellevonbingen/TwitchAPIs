using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.V5
{
    public class TwitchSearchChannels
    {
        public int Total { get; set; }
        public TwitchChannel[] Channels { get; set; }

        public TwitchSearchChannels()
        {

        }

        public TwitchSearchChannels(JToken jToken)
        {
            this.Total = jToken.Value<int>("_total");
            this.Channels = jToken.ReadArray("channels", t => new TwitchChannel(t));
        }

    }

}
