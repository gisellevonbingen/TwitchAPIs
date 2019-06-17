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

        public TwitchGame[] GetGames(string id, string name)
        {
            var apiRequest = new TwitchAPIRequest();
            apiRequest.Version = APIVersion.New;
            apiRequest.Path = "games";
            apiRequest.Method = "GET";
            apiRequest.QueryValues.Add("id", id);
            apiRequest.QueryValues.Add("name", name);
            var jToken = this.Parent.RequestAsJson(apiRequest);

            var games = jToken.ReadArray("data", t => new TwitchGame().Read(t)) ?? new TwitchGame[0];

            return games;
        }

    }

}
