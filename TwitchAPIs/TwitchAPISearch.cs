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
            var apiRequest = new TwitchAPIRequestParameter();
            apiRequest.Version = APIVersion.V5;
            apiRequest.Path = "search/games";
            apiRequest.Method = "GET";
            apiRequest.QueryValues.Add("query", query);
            apiRequest.QueryValues.Add("live", live.ToString());
            var jToken = this.Parent.Request(apiRequest);

            return jToken.ReadArray("games", t => new TwitchGame().Read(t)) ?? new TwitchGame[0];
        }

        public TwitchChannel[] SearchChannels(string query, int? limit = null, int? offset = null)
        {
            var apiRequest = new TwitchAPIRequestParameter();
            apiRequest.Version = APIVersion.V5;
            apiRequest.Path = "search/channels";
            apiRequest.Method = "GET";
            apiRequest.QueryValues.Add("query", query);
            apiRequest.QueryValues.Add("limit", limit.ToString());
            apiRequest.QueryValues.Add("offset", offset.ToString());
            var jToken = this.Parent.Request(apiRequest);

            return jToken.ReadArray("channels", t => new TwitchChannel().Read(t)) ?? new TwitchChannel[0];
        }

    }

}
