using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.New
{
    public class TwitchAPIVideos : TwitchAPIPart
    {
        public TwitchAPIVideos(TwitchAPI parent) : base(parent)
        {

        }

        public TwitchVideos GetVideos(TwitchGetVideosOptions options)
        {
            var apiRequest = new TwitchAPIRequest();
            apiRequest.Version = APIVersion.New;
            apiRequest.Path = "videos";
            apiRequest.Method = "GET";
            apiRequest.QueryValues.AddRange("id", options.Ids);
            apiRequest.QueryValues.Add("user_id", options.UserId);
            apiRequest.QueryValues.Add("game_id", options.GameId);
            apiRequest.QueryValues.Add("after", options.After);
            apiRequest.QueryValues.Add("before", options.Before);
            apiRequest.QueryValues.Add("first", options.First);
            apiRequest.QueryValues.Add("language", options.Language);
            apiRequest.QueryValues.Add("period", options.Period?.Name);
            apiRequest.QueryValues.Add("sort", options.Sort?.Name);
            apiRequest.QueryValues.Add("type", options.Type?.Name);
            var jToken = this.Parent.RequestAsJson(apiRequest);

            return new TwitchVideos(jToken);
        }

    }

}
