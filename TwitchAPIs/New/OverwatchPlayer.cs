using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.New
{
    public class OverwatchPlayer
    {
        public OverwatchHero Hero { get; set; }

        public OverwatchPlayer()
        {

        }

        public OverwatchPlayer(JToken jToken)
        {
            this.Hero = jToken.ReadIfExist(t => new OverwatchHero(t));
        }

    }

}
