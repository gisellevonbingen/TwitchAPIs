using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs
{
    public class TwitchAPIChat : TwitchAPIPart
    {
        public TwitchAPIChat(TwitchAPI parent) : base(parent)
        {

        }

        public TwtichChatRoom[] GetChatRooms(string channelId)
        {
            var apiRequest = new TwitchAPIRequestParameter();
            apiRequest.Version = APIVersion.V5;
            apiRequest.Path = $"chat/{channelId}/rooms";
            apiRequest.Method = "GET";
            var jToken = this.Parent.RequestAsJson(apiRequest);

            return jToken.ReadArray("rooms", t => new TwtichChatRoom().Read(t)) ?? new TwtichChatRoom[0];
        }

    }

}
