using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.V5
{
    public class HLSMode : ValueEnum<bool?>
    {
        public static EnumRegister<HLSMode, bool?> Register { get; } = new EnumRegister<HLSMode, bool?>((o, n, v) => new HLSMode(o, n, v));

        public static HLSMode OnlyHLS { get; } = Register.Generate(nameof(OnlyHLS), true);
        public static HLSMode OnlyRTMP { get; } = Register.Generate(nameof(OnlyRTMP), false);
        public static HLSMode Both { get; } = Register.Generate(nameof(Both), null);

        private HLSMode(int ordinal, string name, bool? value) : base(ordinal, name, value)
        {

        }

    }

}
