using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.V5
{
    public class TwitchTopClips
    {
        public TwitchClip[] Clips { get; set; }
        public string Cursor { get; set; }

        public TwitchTopClips()
        {

        }

        public TwitchTopClips(JToken jToken)
        {
            this.Clips = jToken.ReadArray("clips", t => new TwitchClip(t)) ?? new TwitchClip[0];
            this.Cursor = jToken.Value<string>("_cursor");
        }

    }

}
