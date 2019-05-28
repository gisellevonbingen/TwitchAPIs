using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs
{
    public class TwitchGame
    {
        public string Id { get; set; }
        public TwitchImageSet Box { get; set; }
        public string GiantBombId { get; set; }
        public TwitchImageSet Logo { get; set; }
        public string Name { get; set; }
        public int Popularity { get; set; }

        public TwitchGame()
        {

        }

        public TwitchGame Read(JToken jToken)
        {
            this.Id = jToken.Value<string>("_id");
            this.Box = jToken.ReadIfExist("box", t => new TwitchImageSet().Read(t));
            this.GiantBombId = jToken.Value<string>("giantbomb_id");
            this.Logo = jToken.ReadIfExist("logo", t => new TwitchImageSet().Read(t));
            this.Name = jToken.Value<string>("name");
            this.Popularity = jToken.Value<int>("popularity");

            return this;
        }

    }

}
