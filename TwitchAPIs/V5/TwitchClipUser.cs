using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.V5
{
    public class TwitchClipUser
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string ChannelUrl { get; set; }
        public string Logo { get; set; }

        public TwitchClipUser()
        {

        }

        public TwitchClipUser(JToken jToken)
        {
            this.Id = jToken.Value<string>("id");
            this.Name = jToken.Value<string>("name");
            this.DisplayName = jToken.Value<string>("display_name");
            this.ChannelUrl = jToken.Value<string>("channel_url");
            this.Logo = jToken.Value<string>("logo");
        }

    }

}
