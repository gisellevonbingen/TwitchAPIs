using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace TwitchAPIs.V5
{
    public class TwitchChannelSubscription : TwitchSubscription
    {
        public TwitchUser User { get; set; }

        public TwitchChannelSubscription()
        {

        }

        public TwitchChannelSubscription(JToken jToken) : base(jToken)
        {
            this.User = new TwitchUser(jToken["user"]);
        }

    }

}
