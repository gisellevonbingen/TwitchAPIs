using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace TwitchAPIs
{
    public class TwitchFollow
    {
        public string Id { get; set; }
        public string DisplayName { get; set; }
        public DateTime FollowedAt { get; set; }

        public TwitchFollow()
        {

        }

        public TwitchFollow Read(JToken token, FollowsType type)
        {
            this.Id = token.Value<string>(type.Response + "_id");
            this.DisplayName = token.Value<string>(type.Response + "_name");
            this.FollowedAt = token.Value<DateTime>("followed_at");

            return this;
        }

    }

}
