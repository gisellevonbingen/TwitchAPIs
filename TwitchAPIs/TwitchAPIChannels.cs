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
            var jToken = this.Parent.Request(new TwitchAPIRequestParameter() { Method = "GET", Path = "channel", Version = APIVersion.V5});

            var channel = new TwitchChannel();
            channel.Read(jToken);

            return channel;
        }

        public TwitchChannel GetChannel(string id)
        {
            var jToken = this.Parent.Request(new TwitchAPIRequestParameter() { Method = "GET", Path = $"channels/{id}", Version = APIVersion.V5 });

            var channel = new TwitchChannel();
            channel.Read(jToken);

            return channel;
        }

    }

}
