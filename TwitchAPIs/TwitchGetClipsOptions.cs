using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs
{
    public class TwitchGetClipsOptions
    {
        public string BroadcasterId { get; set; } = null;
        public string GameId { get; set; } = null;
        public List<string> Ids { get; } = new List<string>();
        public string After { get; set; } = null;
        public string Before { get; set; } = null;
        public string EndedAt { get; set; } = null;
        public int? First { get; set; } = null;
        public string StartedAt { get; set; } = null;
    }

}
