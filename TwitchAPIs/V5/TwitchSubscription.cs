using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.V5
{
    public class TwitchSubscription
    {
        public string Id { get; set; }
        public SubscriptionPlan SubPlan { get; set; }
        public string SubPlanName { get; set; }
        public DateTime CreatedAt { get; set; }

        public TwitchSubscription()
        {

        }

        public TwitchSubscription(JToken jToken)
        {
            this.Id = jToken.Value<string>("_id");
            this.SubPlan = SubscriptionPlan.Register.Find(jToken.Value<string>("sub_plan"));
            this.SubPlanName = jToken.Value<string>("sub_plan_name");
            this.CreatedAt = jToken.Value<DateTime>("created_at");
        }

    }

}
