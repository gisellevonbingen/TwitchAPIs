using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.V5
{
    public class TwitchImageSet
    {
        public string Larage { get; set; }
        public string Medium { get; set; }
        public string Small { get; set; }
        public string Template { get; set; }

        public TwitchImageSet()
        {

        }

        public TwitchImageSet(JToken jToken)
        {
            this.Larage = jToken.Value<string>("large");
            this.Medium = jToken.Value<string>("medium");
            this.Small = jToken.Value<string>("small");
            this.Template = jToken.Value<string>("template");
        }

    }

}
