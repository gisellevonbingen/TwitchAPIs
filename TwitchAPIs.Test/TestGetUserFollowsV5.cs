using Giselle.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TwitchAPIs.Test
{
    public class TestGetUserFollowsV5 : TestAbstract
    {
        public TestGetUserFollowsV5()
        {

        }

        private T QueryEnum<T>(UserAbstract user, string message) where T : Enum
        {
            var type = typeof(T);
            var values = Enum.GetValues(type) as T[];
            var index = user.QueryInput(message, values);

            return values[index];
        }

        public override void Run(TestMain main)
        {
            var user = main.User;
            var handler = main.TwitchAPIHandler;

            var userId = user.ReadInput("Enter UserId");
            var limit = NumberUtils.ToIntNullable(user.ReadInput("Enter Limit as int"));
            var offset = NumberUtils.ToIntNullable(user.ReadInput("Enter Offset as int"));
            var direction = this.QueryEnum<FollowSortDirection>(user, "Enter Direction as int");
            var sortby = this.QueryEnum<FollowSortMode>(user, "Enter Sortby as int");
            var userFollows = handler.API.Users.GetUserFollowsV5(userId, limit, offset, direction, sortby);

            main.PrintReflection(user, "UserFollows", userFollows);
        }

    }

}
