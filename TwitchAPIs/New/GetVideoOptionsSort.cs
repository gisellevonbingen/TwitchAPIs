using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Giselle.Commons.Collections;
using Giselle.Commons.Tags;

namespace TwitchAPIs.New
{
    public class GetVideoOptionsSort : SimpleNameTag
    {
        public static SimpleNameTags<GetVideoOptionsSort> Tags { get; } = new SimpleNameTags<GetVideoOptionsSort>();

        public static GetVideoOptionsSort Time { get; } = Tags.AddAndGet(new GetVideoOptionsSort("time"));
        public static GetVideoOptionsSort Trending { get; } = Tags.AddAndGet(new GetVideoOptionsSort("trending"));
        public static GetVideoOptionsSort Views { get; } = Tags.AddAndGet(new GetVideoOptionsSort("views"));

        public GetVideoOptionsSort(string name) : base(name)
        {

        }

    }

}

