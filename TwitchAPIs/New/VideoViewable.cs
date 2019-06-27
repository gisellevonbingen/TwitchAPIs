using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.New
{
    public class VideoViewable : ValueEnum<string>
    {
        public static EnumRegister<VideoViewable, string> Register { get; } = new EnumRegister<VideoViewable, string>((o, n, v) => new VideoViewable(o, n, v));

        public static VideoViewable Public { get; } = Register.Generate(nameof(Public), "public");
        public static VideoViewable Private { get; } = Register.Generate(nameof(Private), "private");

        private VideoViewable(int ordinal, string name, string value) : base(ordinal, name, value)
        {

        }

    }

}

