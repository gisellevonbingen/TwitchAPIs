using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs
{
    public class TwitchBadge
    {
        public string ImageUrl1x { get; set; }
        public string ImageUrl2x { get; set; }
        public string ImageUrl4x { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public string ClickAction { get; set; }
        public string ClickUrl { get; set; }

        public TwitchBadge()
        {

        }

        public TwitchBadge Read(JToken token)
        {
            this.ImageUrl1x = token.Value<string>("image_url_1x");
            this.ImageUrl2x = token.Value<string>("image_url_2x");
            this.ImageUrl4x = token.Value<string>("image_url_4x");
            this.Description = token.Value<string>("description");
            this.Title = token.Value<string>("title");
            this.ClickAction = token.Value<string>("click_action");
            this.ClickUrl = token.Value<string>("click_url");

            return this;
        }

    }

}
