using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.New
{
    public class OverwatchHero
    {
        public string Role { get; set; }
        public string Name { get; set; }
        public string Ability { get; set; }

        public OverwatchHero()
        {

        }

        public OverwatchHero(JToken jToken)
        {
            this.Role = jToken.Value<string>("role");
            this.Name = jToken.Value<string>("name");
            this.Ability = jToken.Value<string>("ability");
        }

    }

}
