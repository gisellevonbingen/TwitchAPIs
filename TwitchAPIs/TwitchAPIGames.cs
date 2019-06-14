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
            var apiRequest = new TwitchAPIRequestParameter();
            apiRequest.Version = APIVersion.V5;
            apiRequest.Path = "games/top";
            apiRequest.Method = "GET";
            apiRequest.QueryValues.Add("limit", limit?.ToString());
            apiRequest.QueryValues.Add("offset", offset?.ToString());
            var jToken = this.Parent.Request(apiRequest);

            var value = new TwitchTopGames();
            value.Read(jToken);

            return value;
        }

    }

}
