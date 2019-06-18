using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace TwitchAPIs.New
{
    public class TwitchClips
    {
        public TwitchClip[] Clips { get; set; }
        public Pagination Pagination { get; set; }

        public TwitchClips()
        {

        }

    }

}
