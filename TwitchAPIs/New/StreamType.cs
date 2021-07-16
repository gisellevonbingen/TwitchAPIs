using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Giselle.Commons.Collections;
using Giselle.Commons.Tags;

namespace TwitchAPIs.New
{
    public class StreamType : SimpleNameTag
    {
        public static SimpleNameTags<StreamType> Tags { get; } = new SimpleNameTags<StreamType>();

        public static StreamType Live { get; } = Tags.AddAndGet(new StreamType("live"));
        public static StreamType None { get; } = Tags.AddAndGet(new StreamType(""));

        public StreamType(string name) : base(name)
        {

        }

    }

}

