using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace TwitchAPIs.New
{
    public class StreamMetadataHearthstone : StreamMetadataAbstract
    {
        public HearthstonePlayer Broadcaster { get; set; }
        public HearthstonePlayer Opponent { get; set; }

        public StreamMetadataHearthstone()
        {

        }

        public StreamMetadataHearthstone(JToken jToken) : base(jToken)
        {
            this.Broadcaster = jToken.ReadIfExist("broadcaster", t => new HearthstonePlayer(t));
            this.Opponent = jToken.ReadIfExist("opponent", t => new HearthstonePlayer(t));
        }

    }

}
