using Giselle.Commons;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.New
{
    public class TwitchStreamTag
    {
        public string Id { get; set; }
        public bool IsAuto { get; set; }
        public Dictionary<string, string> LocalizationNames { get; }
        public Dictionary<string, string> LocalizationDescriptions { get; }

        public TwitchStreamTag()
        {
            this.LocalizationNames = new Dictionary<string, string>();
            this.LocalizationDescriptions = new Dictionary<string, string>();
        }

        public TwitchStreamTag(JToken jToken)
        {
            this.Id = jToken.Value<string>("tag_id");
            this.IsAuto = jToken.Value<bool>("is_auto");
            this.LocalizationNames = jToken.ReadMap("localization_names", (key, t) => new KeyValuePair<string, string>(key, t.Value<string>()));
            this.LocalizationDescriptions = jToken.ReadMap("localization_descriptions", (key, t) => new KeyValuePair<string, string>(key, t.Value<string>()));
        }

    }

}
