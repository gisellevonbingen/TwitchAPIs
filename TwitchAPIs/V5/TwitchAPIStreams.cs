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

        public TwitchStream GetStreamByUser(string channelId, StreamType? type)
        {
            var apiRequest = new TwitchAPIRequest();
            apiRequest.Version = APIVersion.V5;
            apiRequest.Path = $"streams/{channelId}";
            apiRequest.Method = "GET";
            apiRequest.QueryValues.Add("stream_type", type?.ToString().ToLowerInvariant());
            var jToken = this.Parent.RequestAsJson(apiRequest);

            return jToken.ReadIfExist("stream", t => new TwitchStream(t));
        }

        public TwitchLiveStreams GetLiveStreams(TwitchGetLiveStreamsOptions options)
        {
            var apiRequest = new TwitchAPIRequest();
            apiRequest.Version = APIVersion.V5;
            apiRequest.Path = $"streams";
            apiRequest.Method = "GET";
            apiRequest.QueryValues.Add("channel", string.Join(TwitchGetLiveStreamsOptions.ChannelSeparater, options.Channels));
            apiRequest.QueryValues.Add("game", options.Game);
            apiRequest.QueryValues.Add("language", options.Language);
            apiRequest.QueryValues.Add("stream_type", options.StreamType?.ToString().ToLowerInvariant());
            apiRequest.QueryValues.Add("limit", options.Limit);
            apiRequest.QueryValues.Add("offset", options.Offset);
            var jToken = this.Parent.RequestAsJson(apiRequest);

            return new TwitchLiveStreams(jToken);
        }

    }

}
