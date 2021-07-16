using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Giselle.Commons.Collections;
using Giselle.Commons.Tags;

namespace TwitchAPIs.New
{
    public class GetVideoOptionsPeriod : SimpleNameTag
    {
        public static SimpleNameTags<GetVideoOptionsPeriod> Tags { get; } = new SimpleNameTags<GetVideoOptionsPeriod>();

        public static GetVideoOptionsPeriod All { get; } = Tags.AddAndGet(new GetVideoOptionsPeriod("all"));
        public static GetVideoOptionsPeriod Day { get; } = Tags.AddAndGet(new GetVideoOptionsPeriod("day"));
        public static GetVideoOptionsPeriod Week { get; } = Tags.AddAndGet(new GetVideoOptionsPeriod("week"));
        public static GetVideoOptionsPeriod Month { get; } = Tags.AddAndGet(new GetVideoOptionsPeriod("month"));

        public GetVideoOptionsPeriod(string name) : base(name)
        {

        }

    }

}
