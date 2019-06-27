using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.New
{
    public class VideoType : ValueEnum<string>
    {
        public static EnumRegister<VideoType, string> Register { get; } = new EnumRegister<VideoType, string>((o, n, v) => new VideoType(o, n, v));

        public static VideoType Upload { get; } = Register.Generate(nameof(Upload), "upload");
        public static VideoType Archive { get; } = Register.Generate(nameof(Archive), "archive");
        public static VideoType Highlight { get; } = Register.Generate(nameof(Highlight), "highlight");

        private VideoType(int ordinal, string name, string value) : base(ordinal, name, value)
        {

        }

    }

}

