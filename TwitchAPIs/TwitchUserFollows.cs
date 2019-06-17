using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace TwitchAPIs
{
    public class TwitchUserFollows
    {
        public int Total { get; set; }
        public string Cursor { get; set; }
        public TwitchFollowNew[] Follows { get; set; }

        public TwitchUserFollows()
        {

        }

    }

}
