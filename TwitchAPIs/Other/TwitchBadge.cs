using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.Other
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

        public TwitchBadge(JToken jToken)
        {
            this.ImageUrl1x = jToken.Value<string>("image_url_1x");
            this.ImageUrl2x = jToken.Value<string>("image_url_2x");
            this.ImageUrl4x = jToken.Value<string>("image_url_4x");
            this.Description = jToken.Value<string>("description");
            this.Title = jToken.Value<string>("title");
            this.ClickAction = jToken.Value<string>("click_action");
            this.ClickUrl = jToken.Value<string>("click_url");
        }

    }

}
