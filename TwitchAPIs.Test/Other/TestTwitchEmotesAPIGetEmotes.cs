using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Giselle.Commons.Users;

namespace TwitchAPIs.Test.Other
{
    [TwitchAPITest("Other", "TwitchEmotesAPI")]
    public class TestTwitchEmotesAPIGetEmotes : TestAbstract
    {
        public TestTwitchEmotesAPIGetEmotes()
        {

        }

        public override void Run(TestMain main)
        {
            var user = main.User;
            var handler = main.TwitchAPIHandler;

            var emoteIds = user.ReadInputWhileBreakAsString("Enter Emote Id");
            var emotes = handler.API.Other.TwitchEmotesAPI.GetEmotes(emoteIds);

            user.SendMessageAsReflection("Emotes", emotes);
        }

    }

}
