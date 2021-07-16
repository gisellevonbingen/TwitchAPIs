using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.New
{
    public class TwitchStream
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string GameId { get; set; }
        public string[] CommunityIds { get; set; }
        public StreamType Type { get; set; }
        public string Title { get; set; }
        public int ViewerCount { get; set; }
        public DateTime StartedAt { get; set; }
        public string Language { get; set; }
        public string ThumbnailUrl { get; set; }
        public string[] TagIds { get; set; }

        public TwitchStream()
        {

        }

        public TwitchStream(JToken jToken)
        {
            this.Id = jToken.Value<string>("id");
            this.UserId = jToken.Value<string>("user_id");
            this.UserName = jToken.Value<string>("user_name");
            this.GameId = jToken.Value<string>("game_id");
            this.CommunityIds = jToken.ArrayValues<string>("community_ids");
            this.Type = StreamType.Tags.Find(jToken.Value<string>("type"));
            this.Title = jToken.Value<string>("title");
            this.ViewerCount = jToken.Value<int>("viewer_count");
            this.StartedAt = jToken.Value<DateTime>("started_at");
            this.Language = jToken.Value<string>("language");
            this.ThumbnailUrl = jToken.Value<string>("thumbnail_url");
            this.TagIds = jToken.ArrayValues<string>("tag_ids");
        }

    }

}
