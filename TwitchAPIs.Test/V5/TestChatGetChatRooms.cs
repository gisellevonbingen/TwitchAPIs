using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.Test.V5
{
    [TwitchAPITest("V5", "Chat")]
    public class TestChatGetChatRooms : TestAbstract
    {
        public TestChatGetChatRooms()
        {

        }

        public override void Run(TestMain main)
        {
            var user = main.User;
            var handler = main.TwitchAPIHandler;

            var channelId = user.ReadInput("Enter Channel Id").AsString;
            var rooms = handler.API.V5.Chat.GetChatRooms(channelId);

            user.SendMessageAsReflection($"ChatRooms", rooms);
        }

    }

}
