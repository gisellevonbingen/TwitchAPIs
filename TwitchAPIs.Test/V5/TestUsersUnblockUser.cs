using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.Test.V5
{
    [TwitchAPITest("V5", "Users")]
    public class TestUsersUnblockUser : TestAbstract
    {
        public TestUsersUnblockUser()
        {

        }

        public override void Run(TestMain main)
        {
            var user = main.User;
            var handler = main.TwitchAPIHandler;

            var sourceUserId = user.ReadInput("Enter Source User Id").AsString;
            var targetUserId = user.ReadInput("Enter Target User Id").AsString;
            handler.API.V5.Users.UnblockUser(sourceUserId, targetUserId);

            user.SendMessage("UnblockUser");
        }

    }

}
