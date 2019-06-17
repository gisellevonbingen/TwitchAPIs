using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.Test
{
    public class TestGetChatRooms : TestAbstract
    {
        public TestGetChatRooms()
        {

        }

        public override void Run(TestMain main)
        {
            var user = main.User;
            var handler = main.TwitchAPIHandler;

            var channelId = user.ReadInput("Enter Channel-Id");
            var rooms = handler.API.V5.Chat.GetChatRooms(channelId);

            main.PrintReflection(user, $"{channelId}'s Rooms", rooms);
        }

    }

}
