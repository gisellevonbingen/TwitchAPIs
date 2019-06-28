using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.Other.TwitchEmotesAPIs
{
    public class Emote
    {
        public string Code { get; set; }
        public int EmoticonSet { get; set; }
        public string Id { get; set; }
        public string ChannelId { get; set; }
        public string ChannelName { get; set; }

        public Emote()
        {

        }

        public Emote(JToken jToken)
        {
            this.Code = jToken.Value<string>("code");
            this.EmoticonSet = jToken.Value<int>("emoticon_set");
            this.Id = jToken.Value<string>("id");
            this.ChannelId = jToken.Value<string>("channel_id");
            this.ChannelName = jToken.Value<string>("channel_name");
        }

    }

}
