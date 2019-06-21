using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitchAPIs.V5;

namespace TwitchAPIs.Test.V5
{
    [TwitchAPITest("V5", "Channels")]
    public class TestChannelsGetChannelByID : TestAbstract
    {
        public TestChannelsGetChannelByID()
        {

        }

        public override void Run(TestMain main)
        {
            var user = main.User;
            var handler = main.TwitchAPIHandler;

            var api = handler.API;
            var id = user.ReadInput("Enter Channel Id");
            var channel = api.V5.Channels.GetChannelByID(id);

            user.SendMessageAsReflection("TwitchChannel", channel);
        }

    }

}
