using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.New
{
    public class HearthstonePlayer
    {
        public HearthstoneHero Hero { get; set; }

        public HearthstonePlayer()
        {

        }

        public HearthstonePlayer(JToken jToken)
        {
            this.Hero = jToken.ReadIfExist("hero", t => new HearthstoneHero(t));
        }

    }

}
