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
            options.CommunityIds.AddRange(user.ReadInputWhileBreak("Enter Community Id, breakable"));
            options.First = NumberUtils.ToIntNullable(user.ReadInput("Enter First as int"));
            options.GameIds.AddRange(user.ReadInputWhileBreak("Enter Game Id, brekable"));
            options.Languages.AddRange(user.ReadInputWhileBreak("Enter Language, breakable"));
            options.UserIds.AddRange(user.ReadInputWhileBreak("Enter User Id, breakable"));
            options.UserLogins.AddRange(user.ReadInputWhileBreak("Enter User Login, breakable"));

            while (true)
            {
                var streamsMetadata = handler.API.New.Streams.GetStreamsMetadata(options);
                user.SendMessageAsReflection("TwitchStreamsMetadata", streamsMetadata);

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
