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
            var url = $"https://api.twitch.tv/kraken/chat/{channelId}/rooms";

            using (var res = this.Parent.Request(APIVersion.V5, url, "GET"))
            {
                var token = res.ReadAsJSON();
                var roomsToken = token.Value<JArray>("rooms");
                var rooms = new TwtichChatRoom[roomsToken.Count];

                for (int i = 0; i < rooms.Length; i++)
                {
                    var room = rooms[i] = new TwtichChatRoom();
                    var roomToken = roomsToken[i];
                    room.Read(roomToken);
                }

                return rooms;
            }

        }

    }

}
