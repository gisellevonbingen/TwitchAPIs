using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.New
{
    public class StreamType : ValueEnum<string>
    {
        public static EnumRegister<StreamType> Register { get; } = new EnumRegister<StreamType>();

        public static StreamType Live { get; } = new StreamType(nameof(Live), "live");
        public static StreamType None { get; } = new StreamType(nameof(None), "");

        private StreamType(string name, string value) : base(name, value)
        {
            Register.Add(this);
        }

    }

}
