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
            options.BroadcasterId = user.ReadInput("Enter BroadcasterId");
            options.GameId = user.ReadInput("Enter GameId");

            while (true)
            {
                var item = user.ReadInput("Enter Id (Emtpy is break)");

                if (string.IsNullOrWhiteSpace(item) == true)
                {
                    break;
                }

                options.Ids.Add(item);
            }

            options.First = NumberUtils.ToIntNullable(user.ReadInput("Enter First as int"));
            options.StartedAt = TwitchDateTimeUtils.ToDatetime(user.ReadInput("Enter StartedAt as TwtichDateTime"));
            options.EndedAt = TwitchDateTimeUtils.ToDatetime(user.ReadInput("Enter EndedAt as TwtichDateTime"));

            string cursor = null;

            while (true)
            {
                options.After = cursor;
                var clips = handler.API.New.Clips.GetClips(options);
                main.PrintReflection(user, "Clips", clips);

                cursor = clips.Pagination.Cursor;

                if (cursor == null)
                {
                    break;
                }

                Thread.Sleep(1000);
            }

        }

    }

}
