using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.V5
{
    public class TwitchClipThumbnails
    {
        public string Medium { get; set; }
        public string Small { get; set; }
        public string Tiny { get; set; }

        public TwitchClipThumbnails()
        {

        }

        public TwitchClipThumbnails(JToken jToken)
        {
            this.Medium = jToken.Value<string>("medium");
            this.Small = jToken.Value<string>("small");
            this.Tiny = jToken.Value<string>("tiny");
        }

    }

}
