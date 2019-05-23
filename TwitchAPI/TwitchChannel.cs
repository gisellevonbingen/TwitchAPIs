using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPI
{
    public class TwitchChannel
    {
        public string Id { get; set; }
        public string BroadcasterLanguage { get; set; }
        public DateTime CreatedAt { get; set; }
        public string DisplayName { get; set; }
        public int Followers { get; set; }
        public string Game { get; set; }
        public string Language { get; set; }
        public string Logo { get; set; }
        public bool Mature { get; set; }
        public string Name { get; set; }
        public bool Partner { get; set; }
        public string ProfileBanner { get; set; }
        public string ProfileBannerBackgroundColor { get; set; }
        public string Status { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string Url { get; set; }
        public string VideoBanner { get; set; }
        public int Views { get; set; }

    }

}
