using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Giselle.Commons.Collections;
using Giselle.Commons.Tags;

namespace TwitchAPIs.New
{
    public class VideoType : SimpleNameTag
    {
        public static SimpleNameTags<VideoType> Tags { get; } = new SimpleNameTags<VideoType>();

        public static VideoType Upload { get; } = Tags.AddAndGet(new VideoType("upload"));
        public static VideoType Archive { get; } = Tags.AddAndGet(new VideoType("archive"));
        public static VideoType Highlight { get; } = Tags.AddAndGet(new VideoType("highlight"));

        public VideoType(string name) : base(name)
        {

        }

    }

}

