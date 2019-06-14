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
            var path = $"chat/{channelId}/rooms";
            var jToken = this.Parent.Request(APIVersion.V5, path, "GET");

            return jToken.ReadArray("rooms", t => new TwtichChatRoom().Read(t)) ?? new TwtichChatRoom[0];
        }

    }

}
