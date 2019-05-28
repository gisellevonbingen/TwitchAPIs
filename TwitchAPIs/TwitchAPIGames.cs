using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs
{
    public class TwitchAPIGames : TwitchAPIPart
    {
        public TwitchAPIGames(TwitchAPI parent) : base(parent)
        {

        }

        public TwitchTopGames GetTopGames(int? limit = null, int? offset = null)
        {
            var query = new Dictionary<string, string>();

            if (limit.HasValue == true)
            {
                query["limit"] = limit.Value.ToString();
            }

            if (offset.HasValue == true)
            {
                query["offset"] = offset.Value.ToString();
            }

            var url = "https://api.twitch.tv/kraken/games/top";
            var queryToString = string.Join("&", query.Select(pair => $"{pair.Key}={pair.Value}"));

            if (string.IsNullOrEmpty(queryToString) == false)
            {
                url += "?" + queryToString;
            }

            using (var res = this.Parent.Request(APIVersion.V5, url, "GET"))
            {
                var jToken = res.ReadAsJSON();
                var value = new TwitchTopGames();
                value.Read(jToken);

                return value;
            }
            
        }

    }

}
