using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.Test.V5
{
    [TwitchAPITest("V5", "Users")]
    public class TestUsersCheckUserSubscriptionByChannel : TestAbstract
    {
        public TestUsersCheckUserSubscriptionByChannel()
        {

        }

        public override void Run(TestMain main)
        {
            var user = main.User;
            var handler = main.TwitchAPIHandler;

            var userId = user.ReadInput("Enter User Id");
            var channelId = user.ReadInput("Enter Channel Id");
            var subscription = handler.API.V5.Users.CheckUserSubscriptionByChannel(userId, channelId);

            user.SendMessageAsReflection("TwitchUserSubscription", subscription);

        }

    }

}
