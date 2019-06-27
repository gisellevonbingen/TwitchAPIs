using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.V5
{
    public class BroadcasterType : ValueEnum<string>
    {
        public static EnumRegister<BroadcasterType> Register { get; } = new EnumRegister<BroadcasterType>();

        public static BroadcasterType Partner { get; } = new BroadcasterType(nameof(Partner), "partner");
        public static BroadcasterType Affiliate { get; } = new BroadcasterType(nameof(Affiliate), "affiliate");
        public static BroadcasterType None { get; } = new BroadcasterType(nameof(None), "");

        private BroadcasterType(string name, string value) : base(name, value)
        {
            Register.Add(this);
        }

    }

}
