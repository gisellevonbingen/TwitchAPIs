using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.New
{
    public class HearthstoneHero
    {
        public string Type { get; set; }
        public string Class { get; set; }
        public string Name { get; set; }
        public HearthstoneHero()
        {

        }

        public HearthstoneHero(JToken jToken)
        {
            this.Type = jToken.Value<string>("type");
            this.Class = jToken.Value<string>("class");
            this.Name = jToken.Value<string>("name");
        }

    }

}
