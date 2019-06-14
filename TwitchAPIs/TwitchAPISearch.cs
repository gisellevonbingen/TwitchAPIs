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
            var path = $"search/games?query={query}";

            if (live.HasValue == true)
            {
                path += $"&live={live.Value}";
            }

            var jToken = this.Parent.Request(APIVersion.V5, path, "GET");
            return jToken.ReadArray("games", t => new TwitchGame().Read(t)) ?? new TwitchGame[0];
        }

        public TwitchChannel[] SearchChannels(string query, int? limit = null, int? offset = null)
        {
            var path = $"search/channels?query={query}";

            if (limit.HasValue == true)
            {
                path += $"&limit={limit.Value}";
            }

            if (offset.HasValue == true)
            {
                path += $"&offset={offset.Value}";
            }

            var jToken = this.Parent.Request(APIVersion.V5, path, "GET");
            return jToken.ReadArray("channels", t => new TwitchChannel().Read(t)) ?? new TwitchChannel[0];
        }

    }

}
