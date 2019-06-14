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

        public TwitchGameNew[] GetGames(string id, string name)
        {
            var apiRequest = new TwitchAPIRequest();
            apiRequest.Version = APIVersion.New;
            apiRequest.Path = "games";
            apiRequest.Method = "GET";
            apiRequest.QueryValues.Add("id", id);
            apiRequest.QueryValues.Add("name", name);
            var jToken = this.Parent.RequestAsJson(apiRequest);

            var games = jToken.ReadArray("data", t => new TwitchGameNew().Read(t)) ?? new TwitchGameNew[0];

            return games;
        }

        public TwitchTopGames GetTopGames(int? limit = null, int? offset = null)
        {
            var apiRequest = new TwitchAPIRequest();
            apiRequest.Version = APIVersion.V5;
            apiRequest.Path = "games/top";
            apiRequest.Method = "GET";
            apiRequest.QueryValues.Add("limit", limit);
            apiRequest.QueryValues.Add("offset", offset);
            var jToken = this.Parent.RequestAsJson(apiRequest);

            var value = new TwitchTopGames();
            value.Read(jToken);

            return value;
        }

    }

}
