using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.V5
{
    public class TopClipsPeriod : ValueEnum<string>
    {
        public static EnumRegister<TopClipsPeriod> Register { get; } = new EnumRegister<TopClipsPeriod>();

        public static TopClipsPeriod Day { get; } = new TopClipsPeriod(nameof(Day), "day");
        public static TopClipsPeriod Week { get; } = new TopClipsPeriod(nameof(Week), "week");
        public static TopClipsPeriod Month { get; } = new TopClipsPeriod(nameof(Month), "month");
        public static TopClipsPeriod All { get; } = new TopClipsPeriod(nameof(All), "all");

        private TopClipsPeriod(string name, string value) : base(name, value)
        {
            Register.Add(this);
        }

    }

}
