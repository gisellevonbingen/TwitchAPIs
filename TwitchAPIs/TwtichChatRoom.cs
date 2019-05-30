using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs
{
    public class TwtichChatRoom
    {
        public string Id { get; set; }
        public string OwnerId { get; set; }
        public string Name { get; set; }
        public string Topic { get; set; }
        public bool Previewable { get; set; }
        public string MinimumAllowedRole { get; set; }

        public TwtichChatRoom()
        {

        }

        public TwtichChatRoom Read(JToken token)
        {
            this.Id = token.Value<string>("_id");
            this.OwnerId = token.Value<string>("owner_id");
            this.Name = token.Value<string>("name");
            this.Topic = token.Value<string>("topic");
            this.Previewable = token.Value<bool>("is_previewable");
            this.MinimumAllowedRole = token.Value<string>("minimum_allowed_role");

            return this;
        }

    }

}
