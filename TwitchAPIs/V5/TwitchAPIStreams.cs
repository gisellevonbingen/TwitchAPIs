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

    }

}
