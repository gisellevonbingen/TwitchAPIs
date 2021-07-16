using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace TwitchAPIs.New
{
    public class TwitchUser
    {
        public BroadcasterType BroadcasterType { get; set; }
        public string Description { get; set; }
        public string DisplayName { get; set; }
        public string Email { get; set; }
        public string Id { get; set; }
        public string Login { get; set; }
        public string OfflineImageUrl { get; set; }
        public string ProfileImageUrl { get; set; }
        public UserType Type { get; set; }
        public int ViewCount { get; set; }

        public TwitchUser()
        {

        }

        public TwitchUser(JToken jToken)
        {
            this.BroadcasterType = BroadcasterType.Tags.Find(jToken.Value<string>("broadcaster_type"));
            this.Description = jToken.Value<string>("description");
            this.DisplayName = jToken.Value<string>("display_name");
            this.Email = jToken.Value<string>("email");
            this.Id = jToken.Value<string>("id");
            this.Login = jToken.Value<string>("login");
            this.OfflineImageUrl = jToken.Value<string>("offline_image_url");
            this.ProfileImageUrl = jToken.Value<string>("profile_image_url");
            this.Type = UserType.Tags.Find(jToken.Value<string>("type"));
            this.ViewCount = jToken.Value<int>("view_count");
        }

    }

}
