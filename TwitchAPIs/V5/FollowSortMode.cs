using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.V5
{
    public class FollowSortMode : ValueEnum<string>
    {
        public static EnumRegister<FollowSortMode, string> Register { get; } = new EnumRegister<FollowSortMode, string>((o, n, v) => new FollowSortMode(o, n, v));

        public static FollowSortMode CreatedAt { get; } = Register.Generate(nameof(CreatedAt), "created_at");
        public static FollowSortMode LastBroadcast { get; } = Register.Generate(nameof(LastBroadcast), "last_broadcast");
        public static FollowSortMode Login { get; } = Register.Generate(nameof(Login), "login");

        private FollowSortMode(int ordinal, string name, string value) : base(ordinal, name, value)
        {

        }

    }

}

