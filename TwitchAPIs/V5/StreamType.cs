using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Giselle.Commons.Collections;
using Giselle.Commons.Tags;

namespace TwitchAPIs.V5
{
    public class StreamType : SimpleNameTag
    {
        public static SimpleNameTags<StreamType> Tags { get; } = new SimpleNameTags<StreamType>();

        public static StreamType Live { get; } = Tags.AddAndGet(new StreamType("live"));
        public static StreamType Playlist { get; } = Tags.AddAndGet(new StreamType("playlist"));
        public static StreamType All { get; } = Tags.AddAndGet(new StreamType("all"));

        public StreamType(string name) : base(name)
        {

        }

    }

}
