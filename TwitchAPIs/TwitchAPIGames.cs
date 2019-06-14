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

            var path = "games/top";
            var queryToString = string.Join("&", query.Select(pair => $"{pair.Key}={pair.Value}"));

            if (string.IsNullOrEmpty(queryToString) == false)
            {
                path += "?" + queryToString;
            }

            var jToken = this.Parent.Request(APIVersion.V5, path, "GET");
            var value = new TwitchTopGames();
            value.Read(jToken);

            return value;
        }

    }

}
