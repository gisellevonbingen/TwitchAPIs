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
        public string CommunityId { get; set; }
        public int? First { get; set; }
        public string GameId { get; set; }
        public List<string> Languages { get; }
        public string UserId { get; set; }
        public string UserLogin { get; set; }

        public TwitchGetStreamsOptions()
        {
            this.Languages = new List<string>();
        }

    }

}
