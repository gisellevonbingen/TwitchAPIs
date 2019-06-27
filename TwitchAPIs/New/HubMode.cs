using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.New
{
    public class HubMode : ValueEnum<string>
    {
        public static EnumRegister<HubMode, string> Register { get; } = new EnumRegister<HubMode, string>((o, n, v) => new HubMode(o, n, v));

        public static HubMode Subscribe { get; } = Register.Generate(nameof(Subscribe), "subscribe");
        public static HubMode Unsubscribe { get; } = Register.Generate(nameof(Unsubscribe), "unsubscribe");

        private HubMode(int ordinal, string name, string value) : base(ordinal, name, value)
        {

        }

    }

}
