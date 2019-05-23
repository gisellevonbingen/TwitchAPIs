using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace TwitchAPI
{
    public class TwitchUser
    {
        public string BroadcasterType { get; set; }
        public string Description { get; set; }
        public string DisplayName { get; set; }
        public string Email { get; set; }
        public string Id { get; set; }
        public string Login { get; set; }
        public string OfflineImageUrl { get; set; }
        public string ProfileImageUrl { get; set; }
        public string Type { get; set; }
        public int ViewCount { get; set; }

        public TwitchUser()
        {

        }

        public TwitchUser Read(JToken token)
        {
            this.BroadcasterType = token.Value<string>("broadcaster_type");
            this.Description = token.Value<string>("description");
            this.DisplayName = token.Value<string>("display_name");
            this.Email = token.Value<string>("email");
            this.Id = token.Value<string>("id");
            this.Login = token.Value<string>("login");
            this.OfflineImageUrl = token.Value<string>("offline_image_url");
            this.ProfileImageUrl = token.Value<string>("profile_image_url");
            this.Type = token.Value<string>("type");
            this.ViewCount = token.Value<int>("view_count");

            return this;
        }

    }

}
