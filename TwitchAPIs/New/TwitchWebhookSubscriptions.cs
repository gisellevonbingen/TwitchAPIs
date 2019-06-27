using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.New
{
    public class TwitchWebhookSubscriptions
    {
        public int Total { get; set; }
        public TwitchWebhookSubscription[] Subscriptions { get; set; }
        public Pagination Pagination { get; set; }

        public TwitchWebhookSubscriptions()
        {

        }

        public TwitchWebhookSubscriptions(JToken jToken)
        {
            this.Total = jToken.Value<int>("total");
            this.Subscriptions = jToken.ReadArray("data", t => new TwitchWebhookSubscription(t));
            this.Pagination = jToken.ReadIfExist("pagination", t => new Pagination(t));
        }

    }

}
