using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.Test.V5
{
    [TwitchAPITest("V5", "Users")]
    public class TestUsersCheckUserFollowsByChannel : TestAbstract
    {
        public TestUsersCheckUserFollowsByChannel()
        {
        }

        public override void Run(TestMain main)
        {
            var user = main.User;
            var handler = main.TwitchAPIHandler;

            var userId = user.ReadInput("Enter User Id").AsString;
            var channelId = user.ReadInput("Enter Channel Id").AsString;
            var follow = handler.API.V5.Users.CheckUserFollowsByChannel(userId, channelId);

            user.SendMessageAsReflection("Follow", follow);
        }

    }

}
