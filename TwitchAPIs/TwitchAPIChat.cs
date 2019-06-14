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
            var jToken = this.Parent.Request(new TwitchAPIRequestParameter() { Method ="GET", Version = APIVersion.V5, Path = $"chat/{channelId}/rooms" });

            return jToken.ReadArray("rooms", t => new TwtichChatRoom().Read(t)) ?? new TwtichChatRoom[0];
        }

    }

}
