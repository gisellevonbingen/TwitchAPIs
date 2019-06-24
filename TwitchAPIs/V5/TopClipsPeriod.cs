using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.V5
{
    public class TopClipsPeriod
    {
        private static List<TopClipsPeriod> List { get; } = new List<TopClipsPeriod>();
        public static TopClipsPeriod[] Values => List.ToArray();

        public static TopClipsPeriod Day { get; } = new TopClipsPeriod(nameof(Day), "day");
        public static TopClipsPeriod Week { get; } = new TopClipsPeriod(nameof(Week), "week");
        public static TopClipsPeriod Month { get; } = new TopClipsPeriod(nameof(Month), "month");
        public static TopClipsPeriod All { get; } = new TopClipsPeriod(nameof(All), "all");

        public string Name { get; }
        public string Value { get; }

        private TopClipsPeriod(string name, string value)
        {
            this.Name = name;
            this.Value = value;

            List.Add(this);
        }

    }

}
