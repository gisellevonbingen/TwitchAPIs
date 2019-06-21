using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.V5
{
    public class TwitchChannelSubscriptions
    {
        public int Total { get; set; }
        public TwitchChannelSubscription[] Subscriptions { get; set; }

        public TwitchChannelSubscriptions()
        {

        }

        public TwitchChannelSubscriptions(JToken jToken)
        {
            this.Total = jToken.Value<int>("_total");
            this.Subscriptions = jToken.ReadArray("subscriptions", t => new TwitchChannelSubscription(t));
        }

    }

}
