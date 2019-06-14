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

        public TwitchGameV5[] SearchGames(string query, bool? live = null)
        {
            var apiRequest = new TwitchAPIRequest();
            apiRequest.Version = APIVersion.V5;
            apiRequest.Path = "search/games";
            apiRequest.Method = "GET";
            apiRequest.QueryValues.Add("query", query);
            apiRequest.QueryValues.Add("live", live);
            var jToken = this.Parent.RequestAsJson(apiRequest);

            return jToken.ReadArray("games", t => new TwitchGameV5().Read(t)) ?? new TwitchGameV5[0];
        }

        public TwitchChannel[] SearchChannels(string query, int? limit = null, int? offset = null)
        {
            var apiRequest = new TwitchAPIRequest();
            apiRequest.Version = APIVersion.V5;
            apiRequest.Path = "search/channels";
            apiRequest.Method = "GET";
            apiRequest.QueryValues.Add("query", query);
            apiRequest.QueryValues.Add("limit", limit);
            apiRequest.QueryValues.Add("offset", offset);
            var jToken = this.Parent.RequestAsJson(apiRequest);

            return jToken.ReadArray("channels", t => new TwitchChannel().Read(t)) ?? new TwitchChannel[0];
        }

    }

}
