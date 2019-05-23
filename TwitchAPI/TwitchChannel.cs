using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPI
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
        public string BroadcasterType { get; set; }
        public string StreamKey { get; set; }
        public string Email { get; set; }

        public TwitchChannel()
        {

        }

        public TwitchChannel Read(JToken token)
        {
            this.Mature = token.Value<bool>("mature");
            this.Status = token.Value<string>("status");
            this.BroadcasterLanguage = token.Value<string>("broadcaster_language");
            this.DisplayName = token.Value<string>("display_name");
            this.Game = token.Value<string>("game");
            this.Language = token.Value<string>("language");
            this.Id = token.Value<string>("_id");
            this.Name = token.Value<string>("name");
            this.CreatedAt = token.Value<DateTime>("created_at");
            this.UpdatedAt = token.Value<DateTime>("updated_at");
            this.Partner = token.Value<bool>("partner");
            this.Logo = token.Value<string>("logo");
            this.VideoBanner = token.Value<string>("video_banner");
            this.ProfileBanner = token.Value<string>("profile_banner");
            this.ProfileBannerBackgroundColor = token.Value<string>("profile_banner_background_color");
            this.Url = token.Value<string>("url");
            this.Views = token.Value<int>("views");
            this.Followers = token.Value<int>("followers");
            this.BroadcasterType = token.Value<string>("broadcaster_type");
            this.StreamKey = token.Value<string>("stream_key");
            this.Email = token.Value<string>("email");

            return this;
        }

    }

}
