using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.New
{
    public class TwitchStreams
    {
        public TwitchStream[] Streams { get; set; }
        public Pagination Pagination { get; set; }

        public TwitchStreams()
        {

        }

        public TwitchStreams(JToken jToken)
        {
            this.Streams = jToken.ReadArray("data", t => new TwitchStream(t));
            this.Pagination = jToken.ReadIfExist("pagination", t => new Pagination(t));
        }

    }

}
