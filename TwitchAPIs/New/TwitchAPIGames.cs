using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.New
{
    public class TwitchAPIGames : TwitchAPIPart
    {
        public TwitchAPIGames(TwitchAPI parent) : base(parent)
        {

        }

        public TwitchTopGames GetTopGames(string after = null, string before = null, int? first = null)
        {
            var apiRequest = new TwitchAPIRequest();
            apiRequest.Version = APIVersion.New;
            apiRequest.Path = "games/top";
            apiRequest.Method = "GET";
            apiRequest.QueryValues.Add("after", after);
            apiRequest.QueryValues.Add("before", before);
            apiRequest.QueryValues.Add("first", first);
            var jToken = this.Parent.RequestAsJson(apiRequest);

            var topGames = new TwitchTopGames();
            topGames.Games = jToken.ReadArray("data", t => new TwitchGame(t));
            topGames.Pagination = jToken.ReadIfExist("pagination", t => new Pagination(t));

            return topGames;
        }

        public TwitchGame[] GetGames(string id, string name)
        {
            var apiRequest = new TwitchAPIRequest();
            apiRequest.Version = APIVersion.New;
            apiRequest.Path = "games";
            apiRequest.Method = "GET";
            apiRequest.QueryValues.Add("id", id);
            apiRequest.QueryValues.Add("name", name);
            var jToken = this.Parent.RequestAsJson(apiRequest);

            var games = jToken.ReadArray("data", t => new TwitchGame(t));

            return games;
        }

    }

}
