using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace TwitchAPIs
{
    public class TwitchUserFollowsV5
    {
        public int Total { get; set; }
        public TwitchFollowV5[] Follows { get; set; }

        public TwitchUserFollowsV5()
        {

        }

    }

}
