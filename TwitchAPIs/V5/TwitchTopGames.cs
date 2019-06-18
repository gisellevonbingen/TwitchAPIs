using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace TwitchAPIs.V5
{
    public class TwitchTopGames
    {
        public int Total { get; set; }

        public TwitchTopGame[] Top { get; set; }

        public TwitchTopGames()
        {

        }

        public TwitchTopGames(JToken jToken)
        {
            this.Total = jToken.Value<int>("_total");
            this.Top = jToken.ReadArray("top", t => new TwitchTopGame(t)) ?? new TwitchTopGame[0];
        }

    }

}
