using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.V5
{
    public class SubscriptionPlan : ValueEnum<string>
    {
        public static EnumRegister<SubscriptionPlan, string> Register { get; } = new EnumRegister<SubscriptionPlan, string>((o, n, v) => new SubscriptionPlan(o, n, v));

        public static SubscriptionPlan Tier1 { get; } = Register.Generate(nameof(Tier1), "1000");
        public static SubscriptionPlan Tier2 { get; } = Register.Generate(nameof(Tier2), "2000");
        public static SubscriptionPlan Tier3 { get; } = Register.Generate(nameof(Tier3), "3000");

        private SubscriptionPlan(int ordinal, string name, string value) : base(ordinal, name, value)
        {

        }

    }

}
