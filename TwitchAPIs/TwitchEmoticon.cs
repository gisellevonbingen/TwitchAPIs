using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace TwitchAPIs
{
    public class TwitchEmoticon
    {
        public string Code { get; set; }
        public int Id { get; set; }

        public TwitchEmoticon()
        {

        }

        public TwitchEmoticon Read(JToken jToken)
        {
            this.Code = jToken.Value<string>("code");
            this.Id = jToken.Value<int>("id");

            return this;
        }

    }

}
