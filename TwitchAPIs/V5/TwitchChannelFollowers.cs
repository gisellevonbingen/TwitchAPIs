using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.V5
{
    public class TwitchChannelFollowers
    {
        public string Cursor { get; set; }
        public int Total { get; set; }
        public TwitchChannelFollow[] Follows { get; set; }

        public TwitchChannelFollowers()
        {

        }

        public TwitchChannelFollowers Read(JToken jToken)
        {
            this.Cursor = jToken.Value<string>("_cursor");
            this.Total = jToken.Value<int>("_total");
            this.Follows = jToken.ReadArray("follows", t => new TwitchChannelFollow().Read(t));

            return this;
        }

    }

}
