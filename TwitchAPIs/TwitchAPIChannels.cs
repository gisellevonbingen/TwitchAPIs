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
            var url = "https://api.twitch.tv/kraken/channel";

            using (var res = this.Parent.Request(APIVersion.V5, url, "GET"))
            {
                var jToken = this.Parent.EnsureNotError(res.ReadAsJSON());
                var channel = new TwitchChannel();
                channel.Read(jToken);

                return channel;
            }

        }

        public TwitchChannel GetChannel(string id)
        {
            var url = $"https://api.twitch.tv/kraken/channels/{id}";

            using (var res = this.Parent.Request(APIVersion.V5, url, "GET"))
            {
                var jToken = this.Parent.EnsureNotError(res.ReadAsJSON());
                var channel = new TwitchChannel();
                channel.Read(jToken);

                return channel;
            }

        }

    }

}
