using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.V5
{
    public class TwitchTeam
    {
        public string Id { get; set; }
        public string Background { get; set; }
        public string Banner { get; set; }
        public DateTime CreatedAt { get; set; }
        public string DisplayName { get; set; }
        public string Info { get; set; }
        public string Logo { get; set; }
        public string Name { get; set; }
        public DateTime UpdatedAt { get; set; }

        public TwitchTeam()
        {

        }

        public TwitchTeam(JToken jToken)
        {
            this.Id = jToken.Value<string>("_id");
            this.Background = jToken.Value<string>("background");
            this.Banner = jToken.Value<string>("banner");
            this.CreatedAt = jToken.Value<DateTime>("created_at");
            this.DisplayName = jToken.Value<string>("display_name");
            this.Info = jToken.Value<string>("info");
            this.Logo = jToken.Value<string>("logo");
            this.Name = jToken.Value<string>("name");
            this.UpdatedAt = jToken.Value<DateTime>("updated_at");
        }

    }

}
