using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace TwitchAPIs.New
{
    public class TwitchUserFollows
    {
        public int Total { get; set; }
        public TwitchFollow[] Follows { get; set; }
        public Pagination Pagination { get; set; }

        public TwitchUserFollows()
        {

        }

    }

}
