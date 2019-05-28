using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.Test
{
    public class TestUpdateUser : TestAbstract
    {
        public TestUpdateUser()
        {

        }

        public override void Run(TestMain main)
        {
            var user = main.User;
            var handler = main.TwitchAPIHandler;

            var description = user.ReadInput("Enter Descrption");
            var tuser = handler.API.Users.UpdateUser(description);

            main.PrintReflection(user, "Updated User", tuser);
        }

    }

}
