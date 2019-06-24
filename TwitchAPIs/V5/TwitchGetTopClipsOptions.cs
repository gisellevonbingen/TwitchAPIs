using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.V5
{
    public class TwitchGetTopClipsOptions
    {
        public static string LanguageDelimiter { get; } = ",";

        public string Channel { get; set; }
        public string Cursor { get; set; }
        public string Game { get; set; }
        public List<string> Languages { get; } = new List<string>();
        public long? Limit { get; set; }
        public TopClipsPeriod Period { get; set; }
        public bool? Trending { get; set; }
    }

}
