using Giselle.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.Test.V5
{
    [TwitchAPITest("V5", "Teams")]
    public class TestTeamsGetAllTeams : TestAbstract
    {
        public TestTeamsGetAllTeams()
        {

        }

        public override void Run(TestMain main)
        {
            var user = main.User;
            var handler = main.TwitchAPIHandler;

            var limit = user.ReadInput("Enter Limit as int").AsInt;
            var offset = user.ReadInput("Enter Offset as int").AsInt;

            var position = offset ?? 0;

            while (true)
            {
                var teams = handler.API.V5.Teams.GetAllTeams(limit, offset);
                user.SendMessageAsReflection($"Teams {position}~{(position + teams.Length)}", teams);

                position += teams.Length;
                offset = position;

                if (user.ReadBreak() == true)
                {
                    break;
                }

            }

        }

    }

}
