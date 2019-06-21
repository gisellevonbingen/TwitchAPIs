using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.Test.V5
{
    [TwitchAPITest("V5", "Users")]
    public class TestUsersBlockUser : TestAbstract
    {
        public TestUsersBlockUser()
        {

        }

        public override void Run(TestMain main)
        {
            var user = main.User;
            var handler = main.TwitchAPIHandler;

            var sourceUserId = user.ReadInput("Enter Source User Id");
            var targetUserId = user.ReadInput("Enter Target User Id");
            var tuser = handler.API.V5.Users.BlockUser(sourceUserId, targetUserId);

            user.SendMessageAsReflection("BlockUser", tuser);
        }

    }

}
