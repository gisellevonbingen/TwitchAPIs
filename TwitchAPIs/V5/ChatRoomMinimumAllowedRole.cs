using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.V5
{
    public class ChatRoomMinimumAllowedRole : ValueEnum<string>
    {
        public static EnumRegister<ChatRoomMinimumAllowedRole> Register { get; } = new EnumRegister<ChatRoomMinimumAllowedRole>();

        public static ChatRoomMinimumAllowedRole Moderator { get; } = new ChatRoomMinimumAllowedRole(nameof(Moderator), "MODERATOR");
        public static ChatRoomMinimumAllowedRole Subscriber { get; } = new ChatRoomMinimumAllowedRole(nameof(Subscriber), "SUBSCRIBER");
        public static ChatRoomMinimumAllowedRole Everyone { get; } = new ChatRoomMinimumAllowedRole(nameof(Everyone), "EVERYONE");

        private ChatRoomMinimumAllowedRole(string name, string value) : base(name, value)
        {
            Register.Add(this);
        }

    }

}
