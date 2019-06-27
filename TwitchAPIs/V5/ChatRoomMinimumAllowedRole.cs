using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.V5
{
    public class ChatRoomMinimumAllowedRole : ValueEnum<string>
    {
        public static EnumRegister<ChatRoomMinimumAllowedRole, string> Register { get; } = new EnumRegister<ChatRoomMinimumAllowedRole, string>((o, n, v) => new ChatRoomMinimumAllowedRole(o, n, v));

        public static ChatRoomMinimumAllowedRole Moderator { get; } = Register.Generate(nameof(Moderator), "MODERATOR");
        public static ChatRoomMinimumAllowedRole Subscriber { get; } = Register.Generate(nameof(Subscriber), "SUBSCRIBER");
        public static ChatRoomMinimumAllowedRole Everyone { get; } = Register.Generate(nameof(Everyone), "EVERYONE");

        private ChatRoomMinimumAllowedRole(int ordinal, string name, string value) : base(ordinal, name, value)
        {

        }

    }

}

