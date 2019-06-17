using Giselle.Commons;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs
{
    public class TwitchBadgeSet
    {
        public Dictionary<string, Dictionary<string, TwitchBadge>> Set { get; }

        public TwitchBadgeSet()
        {
            this.Set = new Dictionary<string, Dictionary<string, TwitchBadge>>();
        }

        public TwitchBadgeSet Read(JToken token)
        {
            var set = this.Set;
            set.Clear();

            var setToken = token.Value<JObject>("badge_sets");


            if (setToken != null)
            {
                var parseds = setToken.ReadMap((name, nt) =>
                    new KeyValuePair<string, Dictionary<string, TwitchBadge>>(name.ToLowerInvariant(), nt["versions"].ReadMap((version, vt) =>
                        new KeyValuePair<string, TwitchBadge>(version.ToLowerInvariant(), new TwitchBadge().Read(vt)))));

                DictionaryUtils.PutAll(set, parseds);
            }

            return this;
        }

        public TwitchBadge Get(string name, string version)
        {
            if (this.Set.TryGetValue(name.ToLowerInvariant(), out var versions) == false)
            {
                return null;
            }

            if (versions.TryGetValue(version.ToLowerInvariant(), out var badge) == false)
            {
                return null;
            }

            return badge;
        }

    }

}
