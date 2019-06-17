using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.V5
{
    public class TwitchAPIBits : TwitchAPIPart
    {
        public TwitchAPIBits(TwitchAPI parent) : base(parent)
        {

        }

        public TwitchBitAction[] GetCheermotes()
        {
            return this.GetCheermotes(null);
        }

        public TwitchBitAction[] GetCheermotes(string channelId)
        {
            var apiRequest = new TwitchAPIRequest();
            apiRequest.Version = APIVersion.V5;
            apiRequest.Path = "bits/actions";
            apiRequest.Method = "GET";
            apiRequest.QueryValues.Add("channel_id", channelId);
            var jToken = this.Parent.RequestAsJson(apiRequest);

            var array = jToken.ReadArray("actions", t => new TwitchBitAction().Read(t)) ?? new TwitchBitAction[0];
            return array;
        }

    }

}
