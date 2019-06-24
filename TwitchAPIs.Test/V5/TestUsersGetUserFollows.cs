using Giselle.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TwitchAPIs.V5;

namespace TwitchAPIs.Test.V5
{
    [TwitchAPITest("V5", "Users")]
    public class TestUsersGetUserFollows : TestAbstract
    {
        public TestUsersGetUserFollows()
        {

        }

        public override void Run(TestMain main)
        {
            var user = main.User;
            var handler = main.TwitchAPIHandler;

            var userId = user.ReadInput("Enter UserId");
            var limit = NumberUtils.ToIntNullable(user.ReadInput("Enter Limit as int"));
            var offset = NumberUtils.ToIntNullable(user.ReadInput("Enter Offset as int"));
            var direction = user.QueryInput("Enter Direction", EnumUtils.GetNullableValues<SortDirection>(), null, true).Value;
            var sortby = user.QueryInput("Enter Sortby", FollowSortMode.Values, v => v.Name, true).Value;
            var userFollows = handler.API.V5.Users.GetUserFollows(userId, limit, offset, direction, sortby);

            user.SendMessageAsReflection("UserFollows", userFollows);
        }

    }

}
