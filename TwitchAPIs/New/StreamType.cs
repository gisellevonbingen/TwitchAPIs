using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.New
{
    public class StreamType : ValueEnum<string>
    {
        public static EnumRegister<StreamType, string> Register { get; } = new EnumRegister<StreamType, string>((o, n, v) => new StreamType(o, n, v));

        public static StreamType Live { get; } = Register.Generate(nameof(Live), "live");
        public static StreamType None { get; } = Register.Generate(nameof(None), "");

        private StreamType(int ordinal, string name, string value) : base(ordinal, name, value)
        {

        }

    }

}

