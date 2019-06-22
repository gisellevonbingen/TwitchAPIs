using Giselle.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitchAPIs.New;

namespace TwitchAPIs.Test.New
{
    [TwitchAPITest("New", "Streams")]
    public class TestStreamsGetStreams : TestAbstract
    {
        public TestStreamsGetStreams()
        {

        }

        public override void Run(TestMain main)
        {
            var user = main.User;
            var handler = main.TwitchAPIHandler;

            var options = new TwitchGetStreamsOptions();
            options.CommunityId = user.ReadInput("Enter Community Id");
            options.First = NumberUtils.ToIntNullable(user.ReadInput("Enter First as int"));
            options.GameId = user.ReadInput("Enter Game Id");
            options.Language = user.ReadInput("Enter Language");
            options.UserId = user.ReadInput("Enter User Id");
            options.UserLogin = user.ReadInput("Enter User Login");

            while (true)
            {
                var streams = handler.API.New.Streams.GetStreams(options);
                user.SendMessageAsReflection("TwitchStreams", streams);

                options.After = null;
                options.Before = null;
                var index = user.QueryInput("Select Direction", new string[] { "after", "before" }, null, true).Index;

                if (index == -1)
                {
                    break;
                }
                else if (index == 0)
                {
                    options.After = streams.Pagination.Cursor;
                }
                else
                {
                    options.Before = streams.Pagination.Cursor;
                }

            }

        }

    }

}
