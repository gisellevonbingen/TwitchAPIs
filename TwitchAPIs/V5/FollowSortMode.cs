using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.V5
{
    public class FollowSortMode : ValueEnum<string>
    {
        public static EnumRegister<FollowSortMode> Register { get; } = new EnumRegister<FollowSortMode>();

        public static FollowSortMode CreatedAt { get; } = new FollowSortMode(nameof(CreatedAt), "created_at");
        public static FollowSortMode LastBroadcast { get; } = new FollowSortMode(nameof(LastBroadcast), "last_broadcast");
        public static FollowSortMode Login { get; } = new FollowSortMode(nameof(Login), "login");

        private FollowSortMode(string name, string value) : base(name, value)
        {
            Register.Add(this);
        }

    }

}
