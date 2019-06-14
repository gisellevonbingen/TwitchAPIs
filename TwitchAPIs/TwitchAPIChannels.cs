using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs
{
    public class TwitchAPIChannels : TwitchAPIPart
    {
        public TwitchAPIChannels(TwitchAPI parent) : base(parent)
        {

        }

        public TwitchChannel GetChannel()
        {
            var apiRequest = new TwitchAPIRequest();
            apiRequest.Version = APIVersion.V5;
            apiRequest.Path = "channel";
            apiRequest.Method = "GET";
            var jToken = this.Parent.RequestAsJson(apiRequest);

            var channel = new TwitchChannel();
            channel.Read(jToken);

            return channel;
        }

        public TwitchChannel GetChannel(string id)
        {
            var apiRequest = new TwitchAPIRequest();
            apiRequest.Version = APIVersion.V5;
            apiRequest.Path = $"channels/{id}";
            apiRequest.Method = "GET";
            var jToken = this.Parent.RequestAsJson(apiRequest);

            var channel = new TwitchChannel();
            channel.Read(jToken);

            return channel;
        }

    }

}
