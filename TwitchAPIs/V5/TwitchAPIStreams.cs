using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.V5
{
    public class TwitchAPIStreams : TwitchAPIPart
    {
        public TwitchAPIStreams(TwitchAPI parent) : base(parent)
        {

        }

        public TwitchStream GetStreamByUser(string channelId, StreamType type)
        {
            var apiRequest = new TwitchAPIRequest();
            apiRequest.Version = APIVersion.V5;
            apiRequest.Path = $"streams/{channelId}";
            apiRequest.Method = "GET";
            apiRequest.QueryValues.Add("stream_type", type?.Name);
            var jToken = this.Parent.RequestAsJson(apiRequest);

            return jToken.ReadIfExist("stream", t => new TwitchStream(t));
        }

        public TwitchLiveStreams GetLiveStreams(TwitchGetLiveStreamsOptions options)
        {
            var apiRequest = new TwitchAPIRequest();
            apiRequest.Version = APIVersion.V5;
            apiRequest.Path = $"streams";
            apiRequest.Method = "GET";
            apiRequest.QueryValues.Add("channel", string.Join(TwitchAPIV5.QueryArrayValueDelimiter, options.Channels));
            apiRequest.QueryValues.Add("game", options.Game);
            apiRequest.QueryValues.Add("language", options.Language);
            apiRequest.QueryValues.Add("stream_type", options.StreamType?.Name);
            apiRequest.QueryValues.Add("limit", options.Limit);
            apiRequest.QueryValues.Add("offset", options.Offset);
            var jToken = this.Parent.RequestAsJson(apiRequest);

            return new TwitchLiveStreams(jToken);
        }

        public TwitchStreamsSummary GetStreamsSummary(string game = null)
        {
            var apiRequest = new TwitchAPIRequest();
            apiRequest.Version = APIVersion.V5;
            apiRequest.Path = $"streams/summary";
            apiRequest.Method = "GET";
            apiRequest.QueryValues.Add("game", game);
            var jToken = this.Parent.RequestAsJson(apiRequest);

            return new TwitchStreamsSummary(jToken);
        }

        public TwitchFeaturedStream[] GetFeaturedStreams(int? limit = null, int? offset = null)
        {
            var apiRequest = new TwitchAPIRequest();
            apiRequest.Version = APIVersion.V5;
            apiRequest.Path = $"streams/featured";
            apiRequest.Method = "GET";
            apiRequest.QueryValues.Add("limit", limit);
            apiRequest.QueryValues.Add("offset", offset);
            var jToken = this.Parent.RequestAsJson(apiRequest);

            return jToken.ReadArray("featured", t => new TwitchFeaturedStream(t));
        }

        public TwitchFollowedStreams GetFollowedStreams()
        {
            var apiRequest = new TwitchAPIRequest();
            apiRequest.Version = APIVersion.V5;
            apiRequest.Path = $"streams/followed";
            apiRequest.Method = "GET";
            var jToken = this.Parent.RequestAsJson(apiRequest);

            return new TwitchFollowedStreams(jToken);
        }

    }

}
