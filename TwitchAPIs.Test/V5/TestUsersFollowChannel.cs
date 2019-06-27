using Giselle.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.Test.V5
{
    [TwitchAPITest("V5", "Users")]
    public class TestUsersFollowChannel : TestAbstract
    {
        public TestUsersFollowChannel()
        {

        }

        public override void Run(TestMain main)
        {
            var user = main.User;
            var handler = main.TwitchAPIHandler;

            var userId = user.ReadInput("Enter UserId").AsString;
            var channelId = user.ReadInput("Enter ChannelId").AsString;
            var notifications = user.ReadInput("Enter Notifications as bool").AsBool;
            var follow = handler.API.V5.Users.FollowChannel(userId, channelId, notifications);

            user.SendMessageAsReflection("Follow", follow);
        }

    }

}
