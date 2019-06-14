using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs
{
    public class TwitchAPISearch : TwitchAPIPart
    {
        public TwitchAPISearch(TwitchAPI parent) : base(parent)
        {

        }

        public TwitchGame[] SearchGames(string query, bool? live = null)
        {
            var path = $"search/games?query={query}";

            if (live.HasValue == true)
            {
                path += $"&live={live.Value}";
            }

            using (var res = this.Parent.Request(APIVersion.V5, path, "GET"))
            {
                var token = res.ReadAsJSON();
                this.Parent.EnsureNotError(token);
                return this.ParseGames(token["games"] as JArray);
            }

        }

        public TwitchGame[] ParseGames(JArray arrayToken)
        {
            if (arrayToken == null)
            {
                return new TwitchGame[0];
            }

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
            var path = $"search/channels?query={query}";

            if (limit.HasValue == true)
            {
                path += $"&limit={limit.Value}";
            }

            if (offset.HasValue == true)
            {
                path += $"&offset={offset.Value}";
            }

            using (var res = this.Parent.Request(APIVersion.V5, path, "GET"))
            {
                var token = res.ReadAsJSON();
                return this.ParseChannels(token["channels"] as JArray);
            }

        }

        public TwitchChannel[] ParseChannels(JArray arrayToken)
        {
            if (arrayToken == null)
            {
                return new TwitchChannel[0];
            }

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
