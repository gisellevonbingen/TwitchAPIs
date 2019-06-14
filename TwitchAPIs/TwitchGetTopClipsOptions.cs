using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs
{
    public class TwitchGetTopClipsOptions
    {
        public string Channel { get; set; } = null;
        public string Cursor { get; set; } = null;
        public string Game { get; set; } = null;
        public string Language { get; set; } = null;
        public long? Limit { get; set; } = null;
        public string Period { get; set; } = null;
        public bool? Trending { get; set; } = null;
    }

}
