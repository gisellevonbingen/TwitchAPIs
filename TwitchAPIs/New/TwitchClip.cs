using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.New
{
    public class TwitchClip
    {
        public string BroadcasterId { get; set; }
        public string BroadcasterName { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatorId { get; set; }
        public string CreatorName { get; set; }
        public string EmbedUrl { get; set; }
        public string GameId { get; set; }
        public string Id { get; set; }
        public string Language { get; set; }
        public string ThumbnailUrl { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public string VideoId { get; set; }
        public int ViewCount { get; set; }

        public TwitchClip()
        {

        }

        public TwitchClip Read(JToken jToken)
        {
            this.BroadcasterId = jToken.Value<string>("broadcaster_id");
            this.BroadcasterName = jToken.Value<string>("broadcaster_name");
            this.CreatedAt = jToken.Value<DateTime>("created_at");
            this.CreatorId = jToken.Value<string>("creator_id");
            this.CreatorName = jToken.Value<string>("creator_name");
            this.EmbedUrl = jToken.Value<string>("embed_url");
            this.GameId = jToken.Value<string>("game_id");
            this.Id = jToken.Value<string>("id");
            this.Language = jToken.Value<string>("language");
            this.ThumbnailUrl = jToken.Value<string>("thumbnail_url");
            this.Title = jToken.Value<string>("title");
            this.Url = jToken.Value<string>("url");
            this.VideoId = jToken.Value<string>("video_id");
            this.ViewCount = jToken.Value<int>("view_count");

            return this;
        }

    }

}
