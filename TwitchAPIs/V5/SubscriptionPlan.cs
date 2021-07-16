using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Giselle.Commons.Collections;
using Giselle.Commons.Tags;

namespace TwitchAPIs.V5
{
    public class SubscriptionPlan : SimpleNameTag
    {
        public static SimpleNameTags<SubscriptionPlan> Register { get; } = new SimpleNameTags<SubscriptionPlan>();

        public static SubscriptionPlan Tier1 { get; } = Register.AddAndGet(new SubscriptionPlan("1000"));
        public static SubscriptionPlan Tier2 { get; } = Register.AddAndGet(new SubscriptionPlan("2000"));
        public static SubscriptionPlan Tier3 { get; } = Register.AddAndGet(new SubscriptionPlan("3000"));

        public SubscriptionPlan(string name) : base(name)
        {

        }

    }

}
