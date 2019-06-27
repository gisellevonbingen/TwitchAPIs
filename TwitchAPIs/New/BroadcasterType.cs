using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.New
{
    public class BroadcasterType : ValueEnum<string>
    {
        public static EnumRegister<BroadcasterType, string> Register { get; } = new EnumRegister<BroadcasterType, string>((o, n, v) => new BroadcasterType(o, n, v));

        public static BroadcasterType Partner { get; } = Register.Generate(nameof(Partner), "partner");
        public static BroadcasterType Affiliate { get; } = Register.Generate(nameof(Affiliate), "affiliate");
        public static BroadcasterType None { get; } = Register.Generate(nameof(None), "");

        private BroadcasterType(int ordinal, string name, string value) : base(ordinal, name, value)
        {

        }

    }

}
