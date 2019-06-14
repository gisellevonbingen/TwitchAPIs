using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs
{
    public class Pagination
    {
        public string Cursor { get; set; }

        public Pagination()
        {

        }

        public Pagination Read(JToken jToken)
        {
            this.Cursor = jToken.Value<string>("cursor");

            return this;
        }

    }

}
