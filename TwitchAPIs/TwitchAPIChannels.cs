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
            var path = "channel";

            var jToken = this.Parent.Request(APIVersion.V5, path, "GET");
            var channel = new TwitchChannel();
            channel.Read(jToken);

            return channel;
        }

        public TwitchChannel GetChannel(string id)
        {
            var path = $"channels/{id}";

            var jToken = this.Parent.Request(APIVersion.V5, path, "GET");
            var channel = new TwitchChannel();
            channel.Read(jToken);

            return channel;
        }

    }

}
