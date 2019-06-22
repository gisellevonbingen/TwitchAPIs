using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace TwitchAPIs.New
{
    public class StreamMetadataOverwatch : StreamMetadataAbstract
    {
        public OverwatchPlayer Broadcaster { get; set; }

        public StreamMetadataOverwatch()
        {

        }

        public StreamMetadataOverwatch(JToken jToken) : base(jToken)
        {
            this.Broadcaster = jToken.ReadIfExist("broadcaster", t => new OverwatchPlayer(t));
        }

    }

}
