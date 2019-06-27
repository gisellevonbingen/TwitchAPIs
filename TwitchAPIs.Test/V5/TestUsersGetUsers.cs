using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.Test.V5
{
    [TwitchAPITest("V5", "Users")]
    public class TestUsersGetUsers : TestAbstract
    {
        public TestUsersGetUsers()
        {

        }

        public override void Run(TestMain main)
        {
            var user = main.User;
            var handler = main.TwitchAPIHandler;

            var loginList = user.ReadInputWhileBreak("Enter User Login");
            var users = handler.API.V5.Users.GetUsers(loginList);

            user.SendMessageAsReflection("Users", users);
        }

    }

}
