using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.V5
{
    public class TwitchUserBlockList
    {
        public int Total { get; set; }
        public TwitchUser[] Blocks { get; set; }

        public TwitchUserBlockList()
        {

        }

        public TwitchUserBlockList(JToken jToken)
        {
            this.Total = jToken.Value<int>("_total");
            this.Blocks = jToken.ReadArray("blocks", t => t.ReadIfExist("user", t2 => new TwitchUser(t2)));
        }

    }

}
