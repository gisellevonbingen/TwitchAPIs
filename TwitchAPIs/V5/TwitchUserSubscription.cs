using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace TwitchAPIs.V5
{
    public class TwitchUserSubscription : TwitchSubscription
    {
        public TwitchChannel Channel { get; set; }

        public TwitchUserSubscription()
        {
        }

        public TwitchUserSubscription(JToken jToken) : base(jToken)
        {
            this.Channel = new TwitchChannel(jToken["channel"]);
        }

    }

}
