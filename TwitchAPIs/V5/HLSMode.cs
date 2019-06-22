using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.V5
{
    public class HLSMode
    {
        private static List<HLSMode> List { get; } = new List<HLSMode>();
        public static HLSMode[] Values => List.ToArray();

        public static HLSMode OnlyHLS { get; } = new HLSMode(nameof(OnlyHLS), true);
        public static HLSMode OnlyRTMP { get; } = new HLSMode(nameof(OnlyRTMP), false);
        public static HLSMode Both { get; } = new HLSMode(nameof(Both), null);

        public string Name { get; }
        public bool? Value { get; }

        private HLSMode(string name, bool? value)
        {
            this.Name = name;
            this.Value = value;

            List.Add(this);
        }

    }

}
