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
            var queryValues = new Dictionary<string, string>();
            queryValues["limit"] = limit?.ToString();
            queryValues["offset"] = offset?.ToString();
            var jToken = this.Parent.Request(new TwitchAPIRequestParameter() { Method = "GET", Path = "games/top", Version = APIVersion.V5, QueryValues = queryValues });

            var value = new TwitchTopGames();
            value.Read(jToken);

            return value;
        }

    }

}
