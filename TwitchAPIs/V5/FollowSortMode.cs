using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Giselle.Commons.Collections;
using Giselle.Commons.Tags;

namespace TwitchAPIs.V5
{
    public class FollowSortMode : SimpleNameTag
    {
        public static SimpleNameTags<FollowSortMode> Tags { get; } = new SimpleNameTags<FollowSortMode>();

        public static FollowSortMode CreatedAt { get; } = Tags.AddAndGet(new FollowSortMode("created_at"));
        public static FollowSortMode LastBroadcast { get; } = Tags.AddAndGet(new FollowSortMode("last_broadcast"));
        public static FollowSortMode Login { get; } = Tags.AddAndGet(new FollowSortMode("login"));

        public FollowSortMode(string name) : base(name)
        {

        }

    }

}

