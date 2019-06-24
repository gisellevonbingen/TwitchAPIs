using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.V5
{
    public class StreamType
    {
        private static List<StreamType> List { get; } = new List<StreamType>();
        public static StreamType[] Values => List.ToArray();

        public static StreamType Live { get; } = new StreamType(nameof(Live), "live");
        public static StreamType Playlist { get; } = new StreamType(nameof(Playlist), "playlist");
        public static StreamType All { get; } = new StreamType(nameof(All), "all");

        public string Name { get; }
        public string Value { get; }

        private StreamType(string name, string value)
        {
            this.Name = name;
            this.Value = value;

            List.Add(this);
        }

    }

}
