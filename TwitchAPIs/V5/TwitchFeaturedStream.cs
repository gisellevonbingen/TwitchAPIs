using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.V5
{
    public class TwitchFeaturedStream
    {
        public string Image { get; set; }
        public int Priority { get; set; }
        public bool Scheduled { get; set; }
        public bool Sponsored { get; set; }
        public string Text { get; set; }
        public string Title { get; set; }
        public TwitchStream Stream { get; set; }

        public TwitchFeaturedStream()
        {

        }

        public TwitchFeaturedStream(JToken jToken)
        {
            this.Image = jToken.Value<string>("image");
            this.Priority = jToken.Value<int>("priority");
            this.Scheduled = jToken.Value<bool>("scheduled");
            this.Sponsored = jToken.Value<bool>("sponsored");
            this.Text = jToken.Value<string>("text");
            this.Title = jToken.Value<string>("title");
            this.Stream = jToken.ReadIfExist("stream", t => new TwitchStream(t));
        }

    }

}
