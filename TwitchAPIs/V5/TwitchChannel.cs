using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.V5
{
    public class TwitchChannel
    {
        public bool Mature { get; set; }
        public string Status { get; set; }
        public string BroadcasterLanguage { get; set; }
        public string DisplayName { get; set; }
        public string Game { get; set; }
        public string Language { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool Partner { get; set; }
        public string Logo { get; set; }
        public string VideoBanner { get; set; }
        public string ProfileBanner { get; set; }
        public string ProfileBannerBackgroundColor { get; set; }
        public string Url { get; set; }
        public int Views { get; set; }
        public int Followers { get; set; }
        public BroadcasterType BroadcasterType { get; set; }
        public string StreamKey { get; set; }
        public string Email { get; set; }

        public TwitchChannel()
        {

        }

        public TwitchChannel(JToken jToken)
        {
            this.Mature = jToken.Value<bool>("mature");
            this.Status = jToken.Value<string>("status");
            this.BroadcasterLanguage = jToken.Value<string>("broadcaster_language");
            this.DisplayName = jToken.Value<string>("display_name");
            this.Game = jToken.Value<string>("game");
            this.Language = jToken.Value<string>("language");
            this.Id = jToken.Value<string>("_id");
            this.Name = jToken.Value<string>("name");
            this.CreatedAt = jToken.Value<DateTime>("created_at");
            this.UpdatedAt = jToken.Value<DateTime>("updated_at");
            this.Partner = jToken.Value<bool>("partner");
            this.Logo = jToken.Value<string>("logo");
            this.VideoBanner = jToken.Value<string>("video_banner");
            this.ProfileBanner = jToken.Value<string>("profile_banner");
            this.ProfileBannerBackgroundColor = jToken.Value<string>("profile_banner_background_color");
            this.Url = jToken.Value<string>("url");
            this.Views = jToken.Value<int>("views");
            this.Followers = jToken.Value<int>("followers");
            this.BroadcasterType = BroadcasterType.Register.FromValue(jToken.Value<string>("broadcaster_type"));
            this.StreamKey = jToken.Value<string>("stream_key");
            this.Email = jToken.Value<string>("email");
        }

    }

}
