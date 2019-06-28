using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.Test.Other
{
    [TwitchAPITest("Other", "TwitchEmotesAPI")]
    public class TestTwitchEmotesAPIGetEmoteSets : TestAbstract
    {
        public TestTwitchEmotesAPIGetEmoteSets()
        {

        }

        public override void Run(TestMain main)
        {
            var user = main.User;
            var handler = main.TwitchAPIHandler;

            var setIds = user.ReadInputWhileBreak("Enter Emote Set Id");
            var emotes = handler.API.Other.TwitchEmotesAPI.GetEmoteSets(setIds);

            user.SendMessageAsReflection("EmoteSets", emotes);
        }

    }

}
