using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.V5
{
    public class TwitchAPITeam : TwitchAPIPart
    {
        public TwitchAPITeam(TwitchAPI parent) : base(parent)
        {

        }

        public TwitchTeam[] GetAllTeams(int? limit = null, int? offset = null)
        {
            var apiRequest = new TwitchAPIRequest();
            apiRequest.Version = APIVersion.V5;
            apiRequest.Path = "teams";
            apiRequest.Method = "GET";
            apiRequest.QueryValues.Add("limit", limit);
            apiRequest.QueryValues.Add("offset", offset);
            var jToken = this.Parent.RequestAsJson(apiRequest);

            return jToken.ReadArray("teams", t => new TwitchTeam(t)) ?? new TwitchTeam[0];
        }

    }

}
