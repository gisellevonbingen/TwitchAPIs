using Giselle.Commons;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.V5
{
    public class TwitchEmoticonSets
    {
        public Dictionary<string, TwitchEmoticon[]> Set { get; }

        public TwitchEmoticonSets()
        {
            this.Set = new Dictionary<string, TwitchEmoticon[]>();
        }

        public TwitchEmoticonSets(JToken jToken)
        {
            var setToken = jToken.Value<JObject>("emoticon_sets");
            this.Set = setToken.ReadMap((k, v) => new KeyValuePair<string, TwitchEmoticon[]>(k, v.ReadArray(at => new TwitchEmoticon(at))));
        }

    }

}
