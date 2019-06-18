using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.V5
{
    public class TwitchTopGame
    {
        public int Channels { get; set; }
        public int Viewers { get; set; }
        public TwitchGame Game { get; set; }

        public TwitchTopGame()
        {

        }

        public TwitchTopGame(JToken jToken)
        {
            this.Channels = jToken.Value<int>("channels");
            this.Viewers = jToken.Value<int>("viewers");
            this.Game = jToken.ReadIfExist("game", t => new TwitchGame(t));
        }

    }

}
