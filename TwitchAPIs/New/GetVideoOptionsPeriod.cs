using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.New
{
    public class GetVideoOptionsPeriod
    {
        private static List<GetVideoOptionsPeriod> List { get; } = new List<GetVideoOptionsPeriod>();
        public static GetVideoOptionsPeriod[] Values => List.ToArray();

        public static GetVideoOptionsPeriod All { get; } = new GetVideoOptionsPeriod(nameof(All), "all");
        public static GetVideoOptionsPeriod Day { get; } = new GetVideoOptionsPeriod(nameof(Day), "day");
        public static GetVideoOptionsPeriod Week { get; } = new GetVideoOptionsPeriod(nameof(Week), "week");
        public static GetVideoOptionsPeriod Month { get; } = new GetVideoOptionsPeriod(nameof(Month), "month");

        public string Name { get; }
        public string Value { get; }

        private GetVideoOptionsPeriod(string name, string value)
        {
            this.Name = name;
            this.Value = value;

            List.Add(this);
        }

    }

}
