using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.New
{
    public class VideoType : ValueEnum<string>
    {
        public static EnumRegister<VideoType> Register { get; } = new EnumRegister<VideoType>();

        public static VideoType Upload { get; } = new VideoType(nameof(Upload), "upload");
        public static VideoType Archive { get; } = new VideoType(nameof(Archive), "archive");
        public static VideoType Highlight { get; } = new VideoType(nameof(Highlight), "highlight");

        private VideoType(string name, string value) : base(name, value)
        {
            Register.Add(this);
        }

    }

}
