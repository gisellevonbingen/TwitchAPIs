using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.New
{
    public class VideoViewable : ValueEnum<string>
    {
        public static EnumRegister<VideoViewable> Register { get; } = new EnumRegister<VideoViewable>();

        public static VideoViewable Public { get; } = new VideoViewable(nameof(Public), "public");
        public static VideoViewable Private { get; } = new VideoViewable(nameof(Private), "private");

        private VideoViewable(string name, string value) : base(name, value)
        {
            Register.Add(this);
        }

    }

}
