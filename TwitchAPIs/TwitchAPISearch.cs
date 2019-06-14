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
            var queryValues = new Dictionary<string, string>();
            queryValues["query"] = query;
            queryValues["live"] = live.ToString();
            var jToken = this.Parent.Request(new TwitchAPIRequestParameter() { Method = "GET", Path = "search/games", QueryValues = queryValues, Version = APIVersion.V5 });

            return jToken.ReadArray("games", t => new TwitchGame().Read(t)) ?? new TwitchGame[0];
        }

        public TwitchChannel[] SearchChannels(string query, int? limit = null, int? offset = null)
        {
            var queryValues = new Dictionary<string, string>();
            queryValues["query"] = query;
            queryValues["limit"] = limit.ToString();
            queryValues["offset"] = offset.ToString();
            var jToken = this.Parent.Request(new TwitchAPIRequestParameter() { Method = "GET", Path = "search/channels", QueryValues = queryValues, Version = APIVersion.V5 });

            return jToken.ReadArray("channels", t => new TwitchChannel().Read(t)) ?? new TwitchChannel[0];
        }

    }

}
