using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.Test.V5
{
    [TwitchAPITest("V5", "Teams")]
    public class TestTeamsGetTeam : TestAbstract
    {
        public TestTeamsGetTeam()
        {

        }

        public override void Run(TestMain main)
        {
            var user = main.User;
            var handler = main.TwitchAPIHandler;

            var teamName = user.ReadInput("Enter TeamName").AsString;
            var teamAndChannels = handler.API.V5.Teams.GetTeam(teamName);

            user.SendMessageAsReflection("TwitchTeamAndChannels", teamAndChannels);
        }

    }

}
