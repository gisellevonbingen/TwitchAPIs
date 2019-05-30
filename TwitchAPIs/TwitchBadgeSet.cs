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

            foreach (var pair in setToken)
            {
                var name = pair.Key.ToLowerInvariant();
                var versions = new Dictionary<string, TwitchBadge>();
                set[name] = versions;

                var versionsToken = pair.Value.Value<JObject>("versions");

                foreach (var pair2 in versionsToken)
                {
                    var version = pair2.Key.ToLowerInvariant();
                    var badge = new TwitchBadge();
                    badge.Read(pair2.Value);

                    versions[version] = badge;
                }

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
