using Giselle.Commons;
using Giselle.Commons.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitchAPIs.New;

namespace TwitchAPIs.Test.New
{
    [TwitchAPITest("New", "Streams")]
    public class TestStreamsGetStreamsMetadata : TestAbstract
    {
        public TestStreamsGetStreamsMetadata()
        {

        }

        public override void Run(TestMain main)
        {
            var user = main.User;
            var handler = main.TwitchAPIHandler;

            var options = new TwitchGetStreamsOptions();
            options.CommunityIds.AddRange(user.ReadInputWhileBreakAsString("Enter Community Id"));
            options.First = user.ReadInput("Enter First as int").AsInt;
            options.GameIds.AddRange(user.ReadInputWhileBreakAsString("Enter Game Id"));
            options.Languages.AddRange(user.ReadInputWhileBreakAsString("Enter Language"));
            options.UserIds.AddRange(user.ReadInputWhileBreakAsString("Enter User Id"));
            options.UserLogins.AddRange(user.ReadInputWhileBreakAsString("Enter User Login"));

            while (true)
            {
                var streamsMetadata = handler.API.New.Streams.GetStreamsMetadata(options);
                user.SendMessageAsReflection("StreamsMetadata", streamsMetadata);

                options.After = null;
                options.Before = null;
                var index = user.QueryInput("Select Direction", new string[] { "after", "before" }, null, true).Index;

                if (index == -1)
                {
                    break;
                }
                else if (index == 0)
                {
                    options.After = streamsMetadata.Pagination.Cursor;
                }
                else
                {
                    options.Before = streamsMetadata.Pagination.Cursor;
                }

            }

        }

    }

}
