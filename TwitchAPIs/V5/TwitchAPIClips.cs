using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.V5
{
    public class TwitchAPIClips : TwitchAPIPart
    {
        public TwitchAPIClips(TwitchAPI parent) : base(parent)
        {

        }

        public TwitchClip GetClip(string slug)
        {
            var apiRequest = new TwitchAPIRequest();
            apiRequest.Version = APIVersion.V5;
            apiRequest.Path = $"clips/{slug}";
            apiRequest.Method = "GET";
            var jToken = this.Parent.RequestAsJson(apiRequest);

            return new TwitchClip(jToken);
        }

        public TwitchTopClips GetTopClips(TwitchGetTopClipsOptions options)
        {
            var apiRequest = new TwitchAPIRequest();
            apiRequest.Version = APIVersion.V5;
            apiRequest.Path = $"clips/top";
            apiRequest.Method = "GET";
            apiRequest.QueryValues.Add("channel", options.Channel);
            apiRequest.QueryValues.Add("cursor", options.Cursor);
            apiRequest.QueryValues.Add("game", options.Game);
            apiRequest.QueryValues.Add("language", string.Join(TwitchGetTopClipsOptions.LanguageDelimiter, options.Languages));
            apiRequest.QueryValues.Add("limit", options.Limit);
            apiRequest.QueryValues.Add("period", options.Period);
            apiRequest.QueryValues.Add("trending", options.Trending);
            var jToken = this.Parent.RequestAsJson(apiRequest);

            return new TwitchTopClips(jToken);
        }

        public TwitchFollowedClips GetFollowedClips(long? limit, string cursor, bool? trending)
        {
            var apiRequest = new TwitchAPIRequest();
            apiRequest.Version = APIVersion.V5;
            apiRequest.Path = $"clips/followed";
            apiRequest.Method = "GET";
            apiRequest.QueryValues.Add("limit", limit);
            apiRequest.QueryValues.Add("cursor", cursor);
            apiRequest.QueryValues.Add("trending", trending);
            var jToken = this.Parent.RequestAsJson(apiRequest);

            return new TwitchFollowedClips(jToken);
        }

    }

}
