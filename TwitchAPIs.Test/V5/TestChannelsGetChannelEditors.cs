using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.Test.V5
{
    [TwitchAPITest("V5", "Channels")]
    public class TestChannelsGetChannelEditors : TestAbstract
    {
        public TestChannelsGetChannelEditors()
        {

        }

        public override void Run(TestMain main)
        {
            var user = main.User;
            var handler = main.TwitchAPIHandler;

            var channelid = user.ReadInput("Enter Channel Id").AsString;
            var users = handler.API.V5.Channels.GetChannelEditors(channelid);

            user.SendMessageAsReflection("ChannelEditors", users);
        }

    }

}
