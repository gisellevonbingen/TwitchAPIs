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

        public TwitchGame[] SearchGames(string query, bool? live = null)
        {
            var url = $"https://api.twitch.tv/kraken/search/games?query={query}";

            if (live.HasValue == true)
            {
                url += $"&live={live.Value}";
            }

            using (var res = this.Parent.Request(APIVersion.V5, url, "GET"))
            {
                var token = res.ReadAsJSON();
                return this.ParseGames((JArray)token["games"]);
            }

        }

        public TwitchGame[] ParseGames(JArray arrayToken)
        {
            var values = new TwitchGame[arrayToken.Count];

            for (int i = 0; i < values.Length; i++)
            {
                var itemToken = arrayToken[i];
                values[i] = new TwitchGame().Read(itemToken);
            }

            return values;
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
                var value = values[i] = new TwitchChannel();
                value.Read(itemToken);
            }

            return values;
        }

    }

}
