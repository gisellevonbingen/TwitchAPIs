using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.V5
{
    public class TwitchUserOwn : TwitchUser
    {
        public string Email { get; set; }
        public bool EmailVerified { get; set; }
        public TwitchUserNotifications Notifications { get; set; }
        public bool Partnered { get; set; }
        public bool TwitterConnected { get; set; }

        public TwitchUserOwn()
        {

        }

        public TwitchUserOwn(JToken jToken) : base(jToken)
        {
            this.Email = jToken.Value<string>("email");
            this.EmailVerified = jToken.Value<bool>("email_verified");
            this.Notifications = jToken.ReadIfExist("notifications", t => new TwitchUserNotifications(t));
            this.Partnered = jToken.Value<bool>("partnered");
            this.TwitterConnected = jToken.Value<bool>("twitter_connected");
        }

    }

}
