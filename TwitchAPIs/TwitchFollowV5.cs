using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs
{
    public class TwitchFollowV5
    {
        public TwitchChannel Channel { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool Notifications { get; set; }

        public TwitchFollowV5()
        {

        }

        public TwitchFollowV5 Read(JToken jToken)
        {
            this.Channel = new TwitchChannel().Read(jToken["channel"]);
            this.CreatedAt = jToken.Value<DateTime>("created_at");
            this.Notifications = jToken.Value<bool>("notifications");

            return this;
        }

    }

}
