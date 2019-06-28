using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.Other.TwitchEmotesAPIs
{
    public class EmoteSet
    {
        public string SetId { get; set; }
        public string ChannelName { get; set; }
        public string ChannelId { get; set; }
        public int Tier { get; set; }

        public EmoteSet()
        {

        }

        public EmoteSet(JToken jToken)
        {
            this.SetId = jToken.Value<string>("set_id");
            this.ChannelName = jToken.Value<string>("channel_name");
            this.ChannelId = jToken.Value<string>("channel_id");
            this.Tier = jToken.Value<int>("tier");
        }

    }

}
