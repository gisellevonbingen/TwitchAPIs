using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Giselle.Commons.Collections;
using Giselle.Commons.Tags;

namespace TwitchAPIs.New
{
    public class GetVideoOptionsType : SimpleNameTag
    {
        public static SimpleNameTags<GetVideoOptionsType> Tags { get; } = new SimpleNameTags<GetVideoOptionsType>();

        public static GetVideoOptionsType All { get; } = Tags.AddAndGet(new GetVideoOptionsType("all"));
        public static GetVideoOptionsType Upload { get; } = Tags.AddAndGet(new GetVideoOptionsType("upload"));
        public static GetVideoOptionsType Archive { get; } = Tags.AddAndGet(new GetVideoOptionsType("archive"));
        public static GetVideoOptionsType Highlight { get; } = Tags.AddAndGet(new GetVideoOptionsType("highlight"));

        public GetVideoOptionsType(string name) : base(name)
        {

        }

    }

}

