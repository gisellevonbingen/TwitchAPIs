using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.New
{
    public class GetVideoOptionsPeriod : ValueEnum<string>
    {
        public static EnumRegister<GetVideoOptionsPeriod, string> Register { get; } = new EnumRegister<GetVideoOptionsPeriod, string>();

        public static GetVideoOptionsPeriod All { get; } = new GetVideoOptionsPeriod(nameof(All), "all");
        public static GetVideoOptionsPeriod Day { get; } = new GetVideoOptionsPeriod(nameof(Day), "day");
        public static GetVideoOptionsPeriod Week { get; } = new GetVideoOptionsPeriod(nameof(Week), "week");
        public static GetVideoOptionsPeriod Month { get; } = new GetVideoOptionsPeriod(nameof(Month), "month");

        private GetVideoOptionsPeriod(string name, string value) : base(name, value)
        {
            Register.Add(this);
        }

    }

}
