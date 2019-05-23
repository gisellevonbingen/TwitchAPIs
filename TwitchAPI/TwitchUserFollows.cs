using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace TwitchAPI
{
    public class TwitchUserFollows
    {
        public int Total { get; set; }
        public string Cursor { get; set; }
        public TwitchFollow[] Follows { get; set; }

        public TwitchUserFollows()
        {

        }

    }

}
