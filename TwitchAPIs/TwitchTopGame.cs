using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs
{
    public class TwitchTopGame
    {
        public int Channels { get; set; }
        public int Viewers { get; set; }
        public TwitchGameV5 Game { get; set; }

        public TwitchTopGame Read(JToken jToken)
        {
            this.Channels = jToken.Value<int>("channels");
            this.Viewers = jToken.Value<int>("viewers");
            this.Game = jToken.ReadIfExist("game", t => new TwitchGameV5().Read(t));

            return this;
        }

    }

}
