using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.V5
{
    public class SubscriptionPlan : ValueEnum<string>
    {
        public static EnumRegister<SubscriptionPlan, string> Register { get; } = new EnumRegister<SubscriptionPlan, string>();

        public static SubscriptionPlan Tier1 { get; } = new SubscriptionPlan(nameof(Tier1), "1000");
        public static SubscriptionPlan Tier2 { get; } = new SubscriptionPlan(nameof(Tier2), "2000");
        public static SubscriptionPlan Tier3 { get; } = new SubscriptionPlan(nameof(Tier3), "3000");

        private SubscriptionPlan(string name, string value) : base(name, value)
        {
            Register.Add(this);
        }

    }

}
