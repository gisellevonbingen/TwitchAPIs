using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace TwitchAPIs
{
    public class TwitchClips
    {
        public TwitchClip[] Clips { get; set; }
        public string Cursor { get; set; }

        public TwitchClips()
        {

        }

    }

}
