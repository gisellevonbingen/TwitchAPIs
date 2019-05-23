using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPI
{
    public class TwitchAPISearch : TwitchAPIPart
    {
        public TwitchAPISearch(TwitchAPI parent) : base(parent)
        {

        }

        public TwitchChannel[] SearchChannels(string query, int? limit = null, int? offset = null)
        {
            var url = $"https://api.twitch.tv/kraken/search/channels?query={query}";

            if (limit.HasValue == true)
            {
                url += $"&limit={limit.Value}";
            }

            if (offset.HasValue == true)
            {
                url += $"&offset={offset.Value}";
            }

            using (var res = this.Parent.Request(APIVersion.V5, url, "GET"))
            {
                var token = res.ReadAsJSON();
                return this.ParseChannels((JArray) token["channels"]);
            }

        }

        public TwitchChannel[] ParseChannels(JArray arrayToken)
        {
            var values = new TwitchChannel[arrayToken.Count];

            for (int i = 0; i < values.Length; i++)
            {
                var itemToken = arrayToken[i];
                values[i] = this.ParseChannel(itemToken);
            }

            return values;
        }

        public TwitchChannel ParseChannel(JToken token)
        {
            var value = new TwitchChannel();
            value.Id = token.Value<string>("_id");
            value.BroadcasterLanguage = token.Value<string>("broadcaster_language");
            value.CreatedAt = token.Value<DateTime>("created_at");
            value.DisplayName = token.Value<string>("display_name");
            value.Followers = token.Value<int>("followers");
            value.Game = token.Value<string>("game");
            value.Language = token.Value<string>("language");
            value.Logo = token.Value<string>("logo");
            value.Mature = token.Value<bool>("mature");
            value.Name = token.Value<string>("name");
            value.Partner = token.Value<bool>("partner");
            value.ProfileBanner = token.Value<string>("profile_banner");
            value.ProfileBannerBackgroundColor = token.Value<string>("profile_banner_background_color");
            value.Status = token.Value<string>("status");
            value.UpdatedAt = token.Value<DateTime>("updated_at");
            value.Url = token.Value<string>("url");
            value.VideoBanner = token.Value<string>("video_banner");
            value.Views = token.Value<int>("views");


            return value;
        }

    }

}
