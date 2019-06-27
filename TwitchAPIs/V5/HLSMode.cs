using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.V5
{
    public class HLSMode : ValueEnum<bool?>
    {
        public static EnumRegister<HLSMode> Register { get; } = new EnumRegister<HLSMode>();

        public static HLSMode OnlyHLS { get; } = new HLSMode(nameof(OnlyHLS), true);
        public static HLSMode OnlyRTMP { get; } = new HLSMode(nameof(OnlyRTMP), false);
        public static HLSMode Both { get; } = new HLSMode(nameof(Both), null);

        private HLSMode(string name, bool? value) : base(name, value)
        {
            Register.Add(this);
        }

    }

}
