using Giselle.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TwitchAPIs.New;

namespace TwitchAPIs.Test.New
{
    [TwitchAPITest("New", "Users")]
    public class TestUsersGetUserFollows : TestAbstract
    {
        public TestUsersGetUserFollows()
        {

        }

        public override void Run(TestMain main)
        {
            var user = main.User;
            var handler = main.TwitchAPIHandler;

            var first = NumberUtils.ToIntNullable(user.ReadInput("Enter First as int"));
            var fromId = user.ReadInput("Enter From Id, show followings");
            var toId = user.ReadInput("Enter To Id, show followers");

            var api = handler.API;
            string cursor = null;

            while (true)
            {
                var userFollows = api.New.Users.GetUserFollows(cursor, first, fromId, toId);
                user.SendMessageAsReflection("UserFollows", userFollows);

                cursor = userFollows.Pagination.Cursor;

                if (string.IsNullOrWhiteSpace(cursor) == true)
                {
                    break;
                }

                //Thread.Sleep(1000);
            }

        }

    }

}
