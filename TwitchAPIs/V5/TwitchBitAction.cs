using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace TwitchAPIs.V5
{
    public class TwitchBitAction
    {
        public string Prefix { get; set; }
        public string[] Scales { get; set; }
        public string[] Backgrounds { get; set; }
        public string[] States { get; set; }
        public string Type { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int Priority { get; set; }
        public TwitchBitTier[] Tiers { get; set; }

        public TwitchBitAction()
        {

        }

        public TwitchBitAction Read(JToken jToken)
        {
            this.Prefix = jToken.Value<string>("prefix");
            this.Scales = jToken.ReadArray("scales", t => t.Value<string>());
            this.Backgrounds = jToken.ReadArray("backgrounds", t => t.Value<string>());
            this.States = jToken.ReadArray("states", t => t.Value<string>());
            this.Type = jToken.Value<string>("type");
            this.UpdatedAt = jToken.Value<DateTime>("updated_at");
            this.Priority = jToken.Value<int>("priority");
            this.Tiers = jToken.ReadArray("tiers", t => new TwitchBitTier().Read(t));

            return this;
        }

    }

}
