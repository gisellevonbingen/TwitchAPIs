using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.Test
{
    public class TestGetUserEmotes : TestAbstract
    {
        public TestGetUserEmotes()
        {

        }

        public override void Run(TestMain main)
        {
            var user = main.User;
            var handler = main.TwitchAPIHandler;

            var userId = user.ReadInput("Enter UserId");
            var set = handler.API.Users.GetUserEmotes(userId);

            main.PrintReflection(user, "EmoticonSet", set);
        }

    }

}
