using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.New
{
    public class TwitchAllStreamTags
    {
        public TwitchStreamTag[] Tags { get; set; }
        public Pagination Pagination { get; set; }

        public TwitchAllStreamTags()
        {

        }

        public TwitchAllStreamTags(JToken jToken)
        {
            this.Tags = jToken.ReadArray("data", t => new TwitchStreamTag(t));
            this.Pagination = jToken.ReadIfExist("pagination", t => new Pagination(t));
        }

    }

}
