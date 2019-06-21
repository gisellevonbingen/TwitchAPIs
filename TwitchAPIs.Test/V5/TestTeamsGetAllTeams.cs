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

            var limit = NumberUtils.ToIntNullable(user.ReadInput("Enter Limit as int"));
            var offset = NumberUtils.ToIntNullable(user.ReadInput("Enter Offset as int"));

            var position = offset ?? 0;

            while (true)
            {
                var teams = handler.API.V5.Teams.GetAllTeams(limit, offset);
                user.SendMessageAsReflection($"TwitchTeams {position}~{(position + teams.Length)}", teams);

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
