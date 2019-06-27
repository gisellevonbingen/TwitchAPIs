using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.V5
{
    public class TwitchChatRoom
    {
        public string Id { get; set; }
        public string OwnerId { get; set; }
        public string Name { get; set; }
        public string Topic { get; set; }
        public bool Previewable { get; set; }
        public ChatRoomMinimumAllowedRole MinimumAllowedRole { get; set; }

        public TwitchChatRoom()
        {

        }

        public TwitchChatRoom(JToken jToken)
        {
            this.Id = jToken.Value<string>("_id");
            this.OwnerId = jToken.Value<string>("owner_id");
            this.Name = jToken.Value<string>("name");
            this.Topic = jToken.Value<string>("topic");
            this.Previewable = jToken.Value<bool>("is_previewable");
            this.MinimumAllowedRole = ChatRoomMinimumAllowedRole.Register.FromValue(jToken.Value<string>("minimum_allowed_role"));
        }

    }

}
