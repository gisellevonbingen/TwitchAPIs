using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.New
{
    public class TwitchStreamMetadata
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string GameId { get; set; }
        public StreamMetadataOverwatch Overwatch { get; set; }
        public StreamMetadataHearthstone Hearthstone { get; set; }

        public TwitchStreamMetadata()
        {

        }

        public TwitchStreamMetadata(JToken jToken)
        {
            this.UserId = jToken.Value<string>("user_id");
            this.UserName = jToken.Value<string>("user_name");
            this.GameId = jToken.Value<string>("game_id");
            this.Overwatch = jToken.ReadIfExist("overwatch", t => new StreamMetadataOverwatch(t));
            this.Hearthstone = jToken.ReadIfExist("hearthstone", t => new StreamMetadataHearthstone(t));
        }

    }

}
