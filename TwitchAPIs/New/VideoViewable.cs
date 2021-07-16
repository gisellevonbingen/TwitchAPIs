using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Giselle.Commons.Collections;
using Giselle.Commons.Tags;

namespace TwitchAPIs.New
{
    public class VideoViewable : SimpleNameTag
    {
        public static SimpleNameTags<VideoViewable> Tags { get; } = new SimpleNameTags<VideoViewable>();

        public static VideoViewable Public { get; } = Tags.AddAndGet(new VideoViewable("public"));
        public static VideoViewable Private { get; } = Tags.AddAndGet(new VideoViewable("private"));

        public VideoViewable(string name) : base(name)
        {

        }

    }

}

