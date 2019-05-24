using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace TwitchAPI
{
    public class TwitchTopGames
    {
        public int Total { get; set; }

        public TwitchGame[] Top { get; set; }

        public void Read(JToken jToken)
        {
            this.Total = jToken.Value<int>("_total");
            this.Top = jToken.ReadArray("top", t => new TwitchGame().Read(t)) ?? new TwitchGame[0];
        }

    }

}
