using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Giselle.Commons.Collections;
using Giselle.Commons.Tags;

namespace TwitchAPIs.V5
{
    public class ChatRoomMinimumAllowedRole : SimpleNameTag
    {
        public static SimpleNameTags<ChatRoomMinimumAllowedRole> Tags { get; } = new SimpleNameTags<ChatRoomMinimumAllowedRole>();

        public static ChatRoomMinimumAllowedRole Moderator { get; } = Tags.AddAndGet(new ChatRoomMinimumAllowedRole("MODERATOR"));
        public static ChatRoomMinimumAllowedRole Subscriber { get; } = Tags.AddAndGet(new ChatRoomMinimumAllowedRole("SUBSCRIBER"));
        public static ChatRoomMinimumAllowedRole Everyone { get; } = Tags.AddAndGet(new ChatRoomMinimumAllowedRole("EVERYONE"));

        public ChatRoomMinimumAllowedRole(string name) : base(name)
        {

        }

    }

}

