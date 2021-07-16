using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Giselle.Commons.Collections;
using Giselle.Commons.Tags;

namespace TwitchAPIs.V5
{
    public class HLSMode : SimpleNameTag
    {
        public static SimpleNameTags<HLSMode> Tags { get; } = new SimpleNameTags<HLSMode>();

        public static HLSMode OnlyHLS { get; } = Tags.AddAndGet(new HLSMode(nameof(OnlyHLS), true));
        public static HLSMode OnlyRTMP { get; } = Tags.AddAndGet(new HLSMode(nameof(OnlyRTMP), false));
        public static HLSMode Both { get; } = Tags.AddAndGet(new HLSMode(nameof(Both), null));

        public bool? Value { get; }

        public HLSMode(string name, bool? value) : base(name)
        {
            this.Value = value;
        }

    }

}
