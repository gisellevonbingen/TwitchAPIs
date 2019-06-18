using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.Test.V5
{
    [TwitchAPITest("V5", "Users")]
    public class TestUsersUnfollowChannel : TestAbstract
    {
        public TestUsersUnfollowChannel()
        {

        }

        public override void Run(TestMain main)
        {
            var user = main.User;
            var handler = main.TwitchAPIHandler;

            var userId = user.ReadInput("Enter UserId");
            var channelId = user.ReadInput("Enter ChannelId");
            handler.API.V5.Users.UnfollowChannel(userId, channelId);

            user.SendMessage("Unfollowed");
        }

    }

}
