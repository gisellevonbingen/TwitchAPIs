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

    }

}
