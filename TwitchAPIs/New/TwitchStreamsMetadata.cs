using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.New
{
    public class TwitchStreamsMetadata
    {
        public TwitchStreamMetadata[] Metadatas { get; set; }
        public Pagination Pagination { get; set; }

        public TwitchStreamsMetadata()
        {

        }

        public TwitchStreamsMetadata(JToken jToken)
        {
            this.Metadatas = jToken.ReadArray("data", t => new TwitchStreamMetadata(t));
            this.Pagination = jToken.ReadIfExist("pagination", t => new Pagination(t));
        }

    }

}
