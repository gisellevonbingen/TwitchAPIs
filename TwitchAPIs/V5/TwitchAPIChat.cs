using Giselle.Commons;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.V5
{
    public class TwitchAPIChat : TwitchAPIPart
    {
        public TwitchAPIChat(TwitchAPI parent) : base(parent)
        {

        }

        public TwitchEmoticonSets GetChatEmoticonsBySet(List<int> emoteSets = null)
        {
            var apiRequest = new TwitchAPIRequest();
            apiRequest.Version = APIVersion.V5;
            apiRequest.Path = $"chat/emoticon_images";
            apiRequest.Method = "GET";
            apiRequest.QueryValues.Add("emotesets", emoteSets?.Join(TwitchAPIV5.QueryArrayValueDelimiter));
            var jToken = this.Parent.RequestAsJson(apiRequest);

            return new TwitchEmoticonSets(jToken);
        }

        public TwitchChatRoom[] GetChatRooms(string channelId)
        {
            var apiRequest = new TwitchAPIRequest();
            apiRequest.Version = APIVersion.V5;
            apiRequest.Path = $"chat/{channelId}/rooms";
            apiRequest.Method = "GET";
            var jToken = this.Parent.RequestAsJson(apiRequest);

            return jToken.ReadArray("rooms", t => new TwitchChatRoom(t));
        }

    }

}
