using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Giselle.Commons.Collections;
using Giselle.Commons.Tags;

namespace TwitchAPIs.V5
{
    public class SortDirection : SimpleNameTag
    {
        public static SimpleNameTags<SortDirection> Tags { get; } = new SimpleNameTags<SortDirection>();

        public static SortDirection Desc { get; } = Tags.AddAndGet(new SortDirection("desc"));
        public static SortDirection Asc { get; } = Tags.AddAndGet(new SortDirection("asc"));

        public SortDirection(string name) : base(name)
        {

        }

    }

}
