using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.New
{
    public class TwitchClipEdit
    {
        public string Id { get; set; }
        public string EditUrl { get; set; }

        public TwitchClipEdit()
        {

        }

        public TwitchClipEdit(JToken jToken)
        {
            this.Id = jToken.Value<string>("id");
            this.EditUrl = jToken.Value<string>("edit_url");
        }

    }

}
