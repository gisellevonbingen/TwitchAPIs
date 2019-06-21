using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.V5
{
    public class TwitchLiveStreams
    {
        public int Total { get; set; }
        public TwitchStream[] Streams { get; set; }

        public TwitchLiveStreams()
        {

        }

        public TwitchLiveStreams(JToken jToken)
        {
            this.Total = jToken.Value<int>("_total");
            this.Streams = jToken.ReadArray("streams", t => new TwitchStream(t));
        }

    }

}
