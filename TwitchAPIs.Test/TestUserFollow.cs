using Giselle.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.Test
{
    public class TestUserFollow : TestAbstract
    {
        public TestUserFollow()
        {

        }

        public override void Run(TestMain main)
        {
            var user = main.User;
            var handler = main.TwitchAPIHandler;

            var userId = user.ReadInput("Enter UserId");
            var channelId = user.ReadInput("Enter ChannelId");
            var notifications = NumberUtils.ToBoolNullable(user.ReadInput("Enter Notifications as bool"));
            var follow = handler.API.Users.FollowChannel(userId, channelId, notifications);

            main.PrintReflection(user, "Follow", follow);
        }

    }

}
