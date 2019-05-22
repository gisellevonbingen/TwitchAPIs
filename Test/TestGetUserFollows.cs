using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TwitchAPI.Test
{
    public class TestGetUserFollows : TestAbstract
    {
        public TestGetUserFollows()
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
            }.ToArray();

            var userId = user.ReadInput("UserId");
            var input = user.QueryInput("Enter FollowsType", followsTypes.Select(pair => pair.Value).ToArray());
            var followsType = followsTypes[input].Key;

            var crawler = handler.Crawler;
            string cursor = null;

            int index = 0;

            while (true)
            {
                var userFollows = crawler.GetUserFollows(followsType, userId, cursor);
                var follows = userFollows.Follows;

                user.SendMessage($"Total : {userFollows.Total}");
                user.SendMessage($"Cursor : {userFollows.Cursor}");

                foreach (var follow in follows)
                {
                    user.SendMessage($"{index++} - {followsType.Response} {follow.DisplayName} at {follow.FollowedAt.ToString("yyyy-MM-dd HH:mm:ss")}");
                }

                cursor = userFollows.Cursor;

                if (cursor == null)
                {
                    break;
                }

                Thread.Sleep(1000);
            }

        }

    }

}
