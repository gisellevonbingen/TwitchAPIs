using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.New
{
    public class TwitchTopGames
    {
        public TwitchGame[] Games { get; set; }
        public Pagination Pagination { get; set; }

        public TwitchTopGames()
        {

        }

        public TwitchTopGames(JToken jToken)
        {
            this.Games = jToken.ReadArray("data", t => new TwitchGame(t));
            this.Pagination = jToken.ReadIfExist("pagination", t => new Pagination(t));
        }

    }

}
