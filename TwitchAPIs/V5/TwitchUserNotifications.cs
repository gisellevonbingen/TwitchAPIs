using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.V5
{
    public class TwitchUserNotifications
    {
        public bool Email { get; set; }
        public bool Push { get; set; }

        public TwitchUserNotifications()
        {

        }

        public TwitchUserNotifications(JToken jToken)
        {
            this.Email = jToken.Value<bool>("email");
            this.Push = jToken.Value<bool>("push");
        }

    }

}
