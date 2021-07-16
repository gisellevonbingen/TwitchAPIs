using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Giselle.Commons.Users;

namespace TwitchAPIs.Test.V5
{
    [TwitchAPITest("V5", "Chat")]
    public class TestChatGetChatEmoticonsBySet : TestAbstract
    {
        public TestChatGetChatEmoticonsBySet()
        {

        }

        public override void Run(TestMain main)
        {
            var user = main.User;
            var handler = main.TwitchAPIHandler;

            var emoteSets = user.ReadInputWhileBreak("Enter Emote Sets", (u, ir) => ir.AsInt ?? 0);
            var sets = handler.API.V5.Chat.GetChatEmoticonsBySet(emoteSets);

            user.SendMessageAsReflection("EmoticonSets", sets);
        }

    }

}
