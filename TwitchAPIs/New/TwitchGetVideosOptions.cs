using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.New
{
    public class TwitchGetVideosOptions
    {
        public List<string> Ids { get; set; } = new List<string>();
        public string UserId { get; set; }
        public string GameId { get; set; }

        public string After { get; set; }
        public string Before { get; set; }
        public int? First { get; set; }
        public string Language { get; set; }
        public GetVideoOptionsPeriod Period { get; set; }
        public GetVideoOptionsSort Sort { get; set; }
        public GetVideoOptionsType Type { get; set; }

        public TwitchGetVideosOptions()
        {

        }

    }

}
