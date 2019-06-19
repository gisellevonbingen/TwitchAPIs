using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.Test.V5
{
    [TwitchAPITest("V5", "Channels")]
    public class TestChannelsGetChannelTeam : TestAbstract
    {
        public TestChannelsGetChannelTeam()
        {

        }

        public override void Run(TestMain main)
        {
            var user = main.User;
            var handler = main.TwitchAPIHandler;

            var channelId = user.ReadInput("Enter Channel Id");
            var teams = handler.API.V5.Channels.GetChannelTeams(channelId);

            main.PrintReflection(user, "TwtichTeams", teams);
        }

    }

}
