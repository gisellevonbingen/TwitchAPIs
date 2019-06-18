using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.Test.V5
{
    [TwitchAPITest("V5", "Users")]
    public class TestUsersGetUserByID : TestAbstract
    {
        public TestUsersGetUserByID()
        {

        }

        public override void Run(TestMain main)
        {
            var user = main.User;
            var handler = main.TwitchAPIHandler;

            var userId = user.ReadInput("Enter User Id");
            var tuser = handler.API.V5.Users.GetUserByID(userId);

            main.PrintReflection(user, "TwitchUser", tuser);
        }

    }

}
