using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.Test.V5
{
    [TwitchAPITest("V5", "Bits")]
    public class TestBitsGetCheermotes : TestAbstract
    {
        public TestBitsGetCheermotes()
        {

        }

        public override void Run(TestMain main)
        {
            var user = main.User;
            var handler = main.TwitchAPIHandler;

            var channelId = user.ReadInput("Enter ChannelId (Empty is global)");

            var actions = handler.API.V5.Bits.GetCheermotes(channelId);
            user.SendMessageAsReflection("Actions", actions);
        }

    }

}
