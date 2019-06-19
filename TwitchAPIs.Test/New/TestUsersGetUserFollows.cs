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

            var followsTypes = new Dictionary<FollowsType, string>
            {
                { FollowsType.From ,"XXX followed from id, Followings" },
                { FollowsType.To , "XXX follow to id, Followers" }
            };

            var userId = user.ReadInput("UserId");
            var followsType = user.QueryInput("Enter FollowsType", followsTypes, pair => $"{pair.Key.Request} = {pair.Value}").Value.Key;

            var api = handler.API;
            string cursor = null;

            while (true)
            {
                var userFollows = api.New.Users.GetUserFollows(followsType, userId, cursor);
                main.PrintReflection(user, "UserFollows", userFollows);

                cursor = userFollows.Pagination.Cursor;

                if (string.IsNullOrWhiteSpace(cursor) == true)
                {
                    break;
                }

                Thread.Sleep(1000);
            }

        }

    }

}
