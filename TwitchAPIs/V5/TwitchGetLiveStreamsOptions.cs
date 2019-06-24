using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.V5
{
    public class TwitchGetLiveStreamsOptions
    {
        public static string ChannelSeparater { get; } = ",";

        public List<string> Channels { get; }
        public string Game { get; set; }
        public string Language { get; set; }
        public StreamType StreamType { get; set; }
        public int? Limit { get; set; }
        public int? Offset { get; set; }

        public TwitchGetLiveStreamsOptions()
        {
            this.Channels = new List<string>();
        }

    }

}
