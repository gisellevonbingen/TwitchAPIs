using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.V5
{
    public class TwitchFollowedClips
    {
        public TwitchClip[] Clips { get; set; }
        public string Cursor { get; set; }

        public TwitchFollowedClips()
        {

        }

        public TwitchFollowedClips(JToken jToken)
        {
            this.Clips = jToken.ReadArray("clips", t => new TwitchClip(t));
            this.Cursor = jToken.Value<string>("_cursor");
        }

    }

}
