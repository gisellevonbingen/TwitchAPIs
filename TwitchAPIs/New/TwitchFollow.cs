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
        public string FromId { get; set; }
        public string FromName { get; set; }
        public string ToId { get; set; }
        public string ToName { get; set; }
        public DateTime FollowedAt { get; set; }

        public TwitchFollow()
        {

        }

        public TwitchFollow(JToken jToken)
        {
            this.FromId = jToken.Value<string>("from_id");
            this.FromName = jToken.Value<string>("from_name");
            this.ToId = jToken.Value<string>("to_id");
            this.ToName = jToken.Value<string>("to_name");
            this.FollowedAt = jToken.Value<DateTime>("followed_at");
        }

    }

}
