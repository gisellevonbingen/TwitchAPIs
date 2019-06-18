using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.V5
{
    public class TwitchUserBlockList
    {
        public int Total { get; set; }
        public TwitchUser[] Blocks { get; set; }
    }

}
