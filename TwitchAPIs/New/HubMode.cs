using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.New
{
    public class HubMode
    {
        private static List<HubMode> List { get; } = new List<HubMode>();
        public static HubMode[] Values => List.ToArray();

        public static HubMode Subscribe { get; } = new HubMode(nameof(Subscribe), "subscribe");
        public static HubMode Unsubscribe { get; } = new HubMode(nameof(Unsubscribe), "unsubscribe");

        public string Name { get; }
        public string Value { get; }

        private HubMode(string name, string value)
        {
            this.Name = name;
            this.Value = value;

            List.Add(this);
        }


    }

}
