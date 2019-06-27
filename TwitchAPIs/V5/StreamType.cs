using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.V5
{
    public class StreamType : ValueEnum<string>
    {
        public static EnumRegister<StreamType, string> Register { get; } = new EnumRegister<StreamType, string>();

        public static StreamType Live { get; } = new StreamType(nameof(Live), "live");
        public static StreamType Playlist { get; } = new StreamType(nameof(Playlist), "playlist");
        public static StreamType All { get; } = new StreamType(nameof(All), "all");

        private StreamType(string name, string value) : base(name, value)
        {
            Register.Add(this);
        }

    }

}
