using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.V5
{
    public class StreamType : ValueEnum<string>
    {
        public static EnumRegister<StreamType, string> Register { get; } = new EnumRegister<StreamType, string>((o, n, v) => new StreamType(o, n, v));

        public static StreamType Live { get; } = Register.Generate(nameof(Live), "live");
        public static StreamType Playlist { get; } = Register.Generate(nameof(Playlist), "playlist");
        public static StreamType All { get; } = Register.Generate(nameof(All), "all");

        private StreamType(int ordinal, string name, string value) : base(ordinal, name, value)
        {

        }

    }

}
