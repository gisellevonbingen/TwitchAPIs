using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.V5
{
    public class TwitchClip
    {
        public string Slug { get; set; }
        public string TrackingId { get; set; }
        public string Url { get; set; }
        public string EmbedUrl { get; set; }
        public string EmbedHtml { get; set; }
        public TwitchClipUser Broadcaster { get; set; }
        public TwitchClipUser Curator { get; set; }
        public TwitchClipVod Vod { get; set; }
        public string Game { get; set; }
        public string Language { get; set; }
        public string Title { get; set; }
        public int Views { get; set; }
        public double Duration { get; set; }
        public DateTime CreatedAt { get; set; }
        public TwitchClipThumbnails Thumbnails { get; set; }

        public TwitchClip()
        {

        }

        public TwitchClip(JToken jToken)
        {
            this.Slug = jToken.Value<string>("slug");
            this.TrackingId = jToken.Value<string>("tracking_id");
            this.Url = jToken.Value<string>("url");
            this.EmbedUrl = jToken.Value<string>("embed_url");
            this.EmbedHtml = jToken.Value<string>("embed_html");
            this.Broadcaster = new TwitchClipUser(jToken["broadcaster"]);
            this.Curator = new TwitchClipUser(jToken["curator"]);
            this.Vod = new TwitchClipVod(jToken["vod"]);
            this.Game = jToken.Value<string>("game");
            this.Language = jToken.Value<string>("language");
            this.Title = jToken.Value<string>("title");
            this.Views = jToken.Value<int>("views");
            this.Duration = jToken.Value<double>("duration");
            this.CreatedAt = jToken.Value<DateTime>("created_at");
            this.Thumbnails = new TwitchClipThumbnails(jToken["thumbnails"]);
        }

    }

}
