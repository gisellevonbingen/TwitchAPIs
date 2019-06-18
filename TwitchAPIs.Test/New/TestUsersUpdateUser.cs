using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.Test.New
{
    [TwitchAPITestAttribute("New", "Users")]
    public class TestUsersUpdateUser : TestAbstract
    {
        public TestUsersUpdateUser()
        {

        }

        public override void Run(TestMain main)
        {
            var user = main.User;
            var handler = main.TwitchAPIHandler;

            var description = user.ReadInput("Enter Descrption");
            var tuser = handler.API.New.Users.UpdateUser(description);

            main.PrintReflection(user, "Updated User", tuser);
        }

    }

}
