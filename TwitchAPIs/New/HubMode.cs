using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.New
{
    public class HubMode : ValueEnum<string>
    {
        public static EnumRegister<HubMode> Register { get; } = new EnumRegister<HubMode>();

        public static HubMode Subscribe { get; } = new HubMode(nameof(Subscribe), "subscribe");
        public static HubMode Unsubscribe { get; } = new HubMode(nameof(Unsubscribe), "unsubscribe");

        private HubMode(string name, string value) : base(name, value)
        {
            Register.Add(this);
        }

    }

}
