using Giselle.Commons;
using Giselle.Commons.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TwitchAPIs.New;

namespace TwitchAPIs.Test.New
{
    [TwitchAPITest("New", "Clips")]
    public class TestClipsGetClips : TestAbstract
    {
        public TestClipsGetClips()
        {

        }

        public override void Run(TestMain main)
        {
            var user = main.User;
            var handler = main.TwitchAPIHandler;

            var options = new TwitchGetClipsOptions();
            options.BroadcasterId = user.ReadInput("Enter BroadcasterId").AsString;
            options.GameId = user.ReadInput("Enter GameId").AsString;
            options.Ids.AddRange(user.ReadInputWhileBreakAsString("Enter Id"));
            options.First = user.ReadInput("Enter First as int").AsInt;
            options.StartedAt = TwitchDateTimeUtils.ToDatetime(user.ReadInput("Enter StartedAt as TwtichDateTime").AsString);
            options.EndedAt = TwitchDateTimeUtils.ToDatetime(user.ReadInput("Enter EndedAt as TwtichDateTime").AsString);

            string cursor = null;

            while (true)
            {
                options.After = cursor;
                var clips = handler.API.New.Clips.GetClips(options);
                user.SendMessageAsReflection("Clips", clips);

                cursor = clips.Pagination.Cursor;

                if (string.IsNullOrWhiteSpace(cursor) == true)
                {
                    break;
                }

                Thread.Sleep(1000);
            }

        }

    }

}
