using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.New
{
    public class TwitchVideo
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime PublishedAt { get; set; }
        public string Url { get; set; }
        public string ThumbnailUrl { get; set; }
        public string Viewable { get; set; }
        public string ViewCount { get; set; }
        public string Language { get; set; }
        public string Type { get; set; }
        public TimeSpan Duration { get; set; }

        public TwitchVideo()
        {

        }

        public TwitchVideo(JToken jToken)
        {
            this.Id = jToken.Value<string>("id");
            this.UserId = jToken.Value<string>("user_id");
            this.UserName = jToken.Value<string>("user_name");
            this.Title = jToken.Value<string>("title");
            this.Description = jToken.Value<string>("description");
            this.CreatedAt = jToken.Value<DateTime>("created_at");
            this.PublishedAt = jToken.Value<DateTime>("published_at");
            this.Url = jToken.Value<string>("url");
            this.ThumbnailUrl = jToken.Value<string>("thumbnail_url");
            this.Viewable = jToken.Value<string>("viewable");
            this.ViewCount = jToken.Value<string>("view_count");
            this.Language = jToken.Value<string>("language");
            this.Type = jToken.Value<string>("type");
            this.Duration = TwitchTimeSpanUtils.ToTimeSpan(jToken.Value<string>("duration"));
        }

    }

}
