using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Giselle.Commons.Collections;
using Giselle.Commons.Tags;

namespace TwitchAPIs.V5
{
    public class TopClipsPeriod : SimpleNameTag
    {
        public static SimpleNameTags<TopClipsPeriod> Register { get; } = new SimpleNameTags<TopClipsPeriod>();

        public static TopClipsPeriod Day { get; } = Register.AddAndGet(new TopClipsPeriod("day"));
        public static TopClipsPeriod Week { get; } = Register.AddAndGet(new TopClipsPeriod("week"));
        public static TopClipsPeriod Month { get; } = Register.AddAndGet(new TopClipsPeriod("month"));
        public static TopClipsPeriod All { get; } = Register.AddAndGet(new TopClipsPeriod("all"));

        public TopClipsPeriod(string name) : base(name)
        {

        }

    }

}
