using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.Test.V5
{
    [TwitchAPITest("V5", "Users")]
    public class TestUsersGetUser : TestAbstract
    {
        public TestUsersGetUser()
        {
        }

        public override void Run(TestMain main)
        {
            var user = main.User;
            var handler = main.TwitchAPIHandler;

            var tuser = handler.API.V5.Users.GetUser();
            user.SendMessageAsReflection("TwitchUser", tuser);
        }

    }

}
