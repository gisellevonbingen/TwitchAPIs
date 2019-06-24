using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.V5
{
    public class SortDirection
    {
        private static List<SortDirection> List { get; } = new List<SortDirection>();
        public static SortDirection[] Values => List.ToArray();

        public static SortDirection Desc { get; } = new SortDirection(nameof(Desc), "desc");
        public static SortDirection Asc { get; } = new SortDirection(nameof(Asc), "asc");
            
        public string Name { get; }
        public string Value { get; }

        private SortDirection(string name, string value)
        {
            this.Name = name;
            this.Value = value;

            List.Add(this);
        }

    }

}
