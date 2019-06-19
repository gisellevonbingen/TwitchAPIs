using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.V5
{
    public class TwitchFollow
    {
        public TwitchChannel Channel { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool Notifications { get; set; }

        public TwitchFollow()
        {

        }


        public TwitchFollow(JToken jToken)
        {
            this.Channel = jToken.ReadIfExist("channel", t => new TwitchChannel(t));
            this.CreatedAt = jToken.Value<DateTime>("created_at");
            this.Notifications = jToken.Value<bool>("notifications");
        }

    }

}
