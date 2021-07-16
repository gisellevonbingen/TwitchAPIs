using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Giselle.Commons.Collections;
using Giselle.Commons.Tags;

namespace TwitchAPIs.New
{
    public class HubMode : SimpleNameTag
    {
        public static SimpleNameTags<HubMode> Tags { get; } = new SimpleNameTags<HubMode>();

        public static HubMode Subscribe { get; } = Tags.AddAndGet(new HubMode("subscribe"));
        public static HubMode Unsubscribe { get; } = Tags.AddAndGet(new HubMode("unsubscribe"));

        public HubMode(string name) : base(name)
        {

        }

    }

}
