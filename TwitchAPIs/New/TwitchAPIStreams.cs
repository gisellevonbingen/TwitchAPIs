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
            apiRequest.QueryValues.AddRange("community_id", options.CommunityIds);
            apiRequest.QueryValues.Add("first", options.First);
            apiRequest.QueryValues.AddRange("game_id", options.GameIds);
            apiRequest.QueryValues.AddRange("language", options.Languages);
            apiRequest.QueryValues.AddRange("user_id", options.UserIds);
            apiRequest.QueryValues.AddRange("user_login", options.UserLogins);
            var jToken = this.Parent.RequestAsJson(apiRequest);

            return new TwitchStreams(jToken);
        }

        public TwitchStreamsMetadata GetStreamsMetadata(TwitchGetStreamsOptions options)
        {
            var apiRequest = new TwitchAPIRequest();
            apiRequest.Version = APIVersion.New;
            apiRequest.Path = "streams/metadata";
            apiRequest.Method = "GET";
            apiRequest.QueryValues.Add("after", options.After);
            apiRequest.QueryValues.Add("before", options.Before);
            apiRequest.QueryValues.AddRange("community_id", options.CommunityIds);
            apiRequest.QueryValues.Add("first", options.First);
            apiRequest.QueryValues.AddRange("game_id", options.GameIds);
            apiRequest.QueryValues.AddRange("language", options.Languages);
            apiRequest.QueryValues.AddRange("user_id", options.UserIds);
            apiRequest.QueryValues.AddRange("user_login", options.UserLogins);
            var jToken = this.Parent.RequestAsJson(apiRequest);

            return new TwitchStreamsMetadata(jToken);
        }

    }

}
