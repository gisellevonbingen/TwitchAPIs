using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace TwitchAPIs.New
{
    public class TwitchFollow
    {
        public string Id { get; set; }
        public string DisplayName { get; set; }
        public DateTime FollowedAt { get; set; }

        public TwitchFollow()
        {

        }

        public TwitchFollow Read(JToken jToken, FollowsType type)
        {
            this.Id = jToken.Value<string>(type.Response + "_id");
            this.DisplayName = jToken.Value<string>(type.Response + "_name");
            this.FollowedAt = jToken.Value<DateTime>("followed_at");

            return this;
        }

    }

}
