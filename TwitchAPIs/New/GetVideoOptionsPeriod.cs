using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.New
{
    public class GetVideoOptionsPeriod : ValueEnum<string>
    {
        public static EnumRegister<GetVideoOptionsPeriod, string> Register { get; } = new EnumRegister<GetVideoOptionsPeriod, string>((o, n, v) => new GetVideoOptionsPeriod(o, n, v));

        public static GetVideoOptionsPeriod All { get; } = Register.Generate(nameof(All), "all");
        public static GetVideoOptionsPeriod Day { get; } = Register.Generate(nameof(Day), "day");
        public static GetVideoOptionsPeriod Week { get; } = Register.Generate(nameof(Week), "week");
        public static GetVideoOptionsPeriod Month { get; } = Register.Generate(nameof(Month), "month");

        private GetVideoOptionsPeriod(int ordinal, string name, string value) : base(ordinal, name, value)
        {

        }

    }

}
