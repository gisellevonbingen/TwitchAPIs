using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.New
{
    public class TwitchWebhookSubscription
    {
        public string Topic { get; set; }
        public string Callback { get; set; }
        public DateTime ExpiresAt { get; set; }

        public TwitchWebhookSubscription()
        {

        }

        public TwitchWebhookSubscription(JToken jToken)
        {
            this.Topic = jToken.Value<string>("topic");
            this.Callback = jToken.Value<string>("callback");
            this.ExpiresAt = jToken.Value<DateTime>("expires_at");
        }

    }

}
