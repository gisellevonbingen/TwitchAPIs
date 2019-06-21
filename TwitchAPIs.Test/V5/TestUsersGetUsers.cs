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

            var loginList = new List<string>();

            while (true)
            {
                var login = user.ReadInput("Enter User Login while break");

                if (user.IsBreak(login) == true)
                {
                    break;
                }
                else
                {
                    loginList.Add(login);
                }

            }

            var users = handler.API.V5.Users.GetUsers(loginList);

            user.SendMessageAsReflection("TwtichUsers", users);
        }

    }

}
