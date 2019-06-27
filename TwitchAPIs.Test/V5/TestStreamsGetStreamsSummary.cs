using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.Test.V5
{
    [TwitchAPITest("V5", "Streams")]
    public class TestStreamsGetStreamsSummary : TestAbstract
    {
        public TestStreamsGetStreamsSummary()
        {

        }

        public override void Run(TestMain main)
        {
            var user = main.User;
            var handler = main.TwitchAPIHandler;

            var game = user.ReadInput("Enter Game").AsString;
            var streamsSummary = handler.API.V5.Streams.GetStreamsSummary(game);

            user.SendMessageAsReflection("StreamsSummary", streamsSummary);
        }

    }

}
