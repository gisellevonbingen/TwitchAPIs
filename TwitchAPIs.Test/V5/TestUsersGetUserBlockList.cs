using Giselle.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.Test.V5
{
    [TwitchAPITest("V5", "Users")]
    public class TestUsersGetUserBlockList : TestAbstract
    {
        public TestUsersGetUserBlockList()
        {

        }

        public override void Run(TestMain main)
        {
            var user = main.User;
            var handler = main.TwitchAPIHandler;

            var userId = user.ReadInput("Enter User Id").AsString;
            var limit = user.ReadInput("Enter Limit as int").AsInt;
            var offset = user.ReadInput("Enter Offset as int").AsInt;
            var blockList = handler.API.V5.Users.GetUserBlockList(userId, limit, offset);

            user.SendMessageAsReflection("TwitchUserBlockList", blockList);
        }

    }

}
