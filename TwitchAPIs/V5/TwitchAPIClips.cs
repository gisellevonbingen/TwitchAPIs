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

    }

}
