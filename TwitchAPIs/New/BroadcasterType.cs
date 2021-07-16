using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Giselle.Commons.Collections;
using Giselle.Commons.Tags;

namespace TwitchAPIs.New
{
    public class BroadcasterType : SimpleNameTag
    {
        public static SimpleNameTags<BroadcasterType> Tags { get; } = new SimpleNameTags<BroadcasterType>();

        public static BroadcasterType Partner { get; } = Tags.AddAndGet(new BroadcasterType("partner"));
        public static BroadcasterType Affiliate { get; } = Tags.AddAndGet(new BroadcasterType("affiliate"));
        public static BroadcasterType None { get; } = Tags.AddAndGet(new BroadcasterType(""));

        public BroadcasterType(string name) : base(name)
        {

        }

    }

}
