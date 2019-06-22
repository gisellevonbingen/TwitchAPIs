using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.New
{
    public class TwitchAPIStreams : TwitchAPIPart
    {
        public TwitchAPIStreams(TwitchAPI parent) : base(parent)
        {

        }

        public TwitchStreams GetStreams(TwitchGetStreamsOptions options)
        {
            var apiRequest = new TwitchAPIRequest();
            apiRequest.Version = APIVersion.New;
            apiRequest.Path = "streams";
            apiRequest.Method = "GET";
            apiRequest.QueryValues.Add("after", options.After);
            apiRequest.QueryValues.Add("before", options.Before);
            apiRequest.QueryValues.Add("community_id", options.CommunityId);
            apiRequest.QueryValues.Add("first", options.First);
            apiRequest.QueryValues.Add("game_id", options.GameId);
            apiRequest.QueryValues.Add("language", options.Language);
            apiRequest.QueryValues.Add("user_id", options.UserId);
            apiRequest.QueryValues.Add("user_login", options.UserLogin);
            var jToken = this.Parent.RequestAsJson(apiRequest);

            return new TwitchStreams(jToken);
        }

    }

}
