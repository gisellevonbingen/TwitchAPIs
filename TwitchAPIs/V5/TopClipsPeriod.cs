using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.V5
{
    public class TopClipsPeriod : ValueEnum<string>
    {
        public static EnumRegister<TopClipsPeriod, string> Register { get; } = new EnumRegister<TopClipsPeriod, string>((o, n, v) => new TopClipsPeriod(o, n, v));

        public static TopClipsPeriod Day { get; } = Register.Generate(nameof(Day), "day");
        public static TopClipsPeriod Week { get; } = Register.Generate(nameof(Week), "week");
        public static TopClipsPeriod Month { get; } = Register.Generate(nameof(Month), "month");
        public static TopClipsPeriod All { get; } = Register.Generate(nameof(All), "all");

        private TopClipsPeriod(int ordinal, string name, string value) : base(ordinal, name, value)
        {

        }

    }

}
