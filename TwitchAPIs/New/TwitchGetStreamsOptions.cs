using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.New
{
    public class TwitchGetStreamsOptions
    {
        public string After { get; set; }
        public string Before { get; set; }
        public List<string> CommunityIds { get; } = new List<string>();
        public int? First { get; set; }
        public List<string> GameIds { get; } = new List<string>();
        public List<string> Languages { get; } = new List<string>();
        public List<string> UserIds { get; set; } = new List<string>();
        public List<string> UserLogins { get; set; } = new List<string>();

    }

}
