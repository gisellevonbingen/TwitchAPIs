using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace TwitchAPIs.V5
{
    public class TwitchUserFollows
    {
        public int Total { get; set; }
        public TwitchFollow[] Follows { get; set; }

        public TwitchUserFollows()
        {

        }

        public TwitchUserFollows(JToken jToken)
        {
            this.Total = jToken.Value<int>("_total");
            this.Follows = jToken.ReadArray("follows", t => new TwitchFollow(t));
        }

    }

}
