using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.V5
{
    public class FollowSortMode
    {
        private static List<FollowSortMode> List { get; } = new List<FollowSortMode>();
        public static FollowSortMode[] Values => List.ToArray();

        public static FollowSortMode CreatedAt { get; } = new FollowSortMode(nameof(CreatedAt), "created_at");
        public static FollowSortMode LastBroadcast { get; } = new FollowSortMode(nameof(LastBroadcast), "last_broadcast");
        public static FollowSortMode Login { get; } = new FollowSortMode(nameof(Login), "login");
            
        public string Name { get; }
        public string Value { get; }

        private FollowSortMode(string name, string value)
        {
            this.Name = name;
            this.Value = value;

            List.Add(this);
        }

    }

}
