using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.Test.New
{
    [TwitchAPITest("New", "Users")]
    public class TestUsersUpdateUser : TestAbstract
    {
        public TestUsersUpdateUser()
        {

        }

        public override void Run(TestMain main)
        {
            var user = main.User;
            var handler = main.TwitchAPIHandler;

            var description = user.ReadInput("Enter Descrption").AsString;
            var tuser = handler.API.New.Users.UpdateUser(description);

            user.SendMessageAsReflection("Updated User", tuser);
        }

    }

}
