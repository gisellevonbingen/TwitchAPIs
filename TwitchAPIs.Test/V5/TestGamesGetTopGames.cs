using Giselle.Commons;
using Giselle.Commons.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.Test.V5
{
    [TwitchAPITest("V5", "Games")]
    public class TestGamesGetTopGames : TestAbstract
    {
        public TestGamesGetTopGames()
        {

        }

        public override void Run(TestMain main)
        {
            var user = main.User;
            var handler = main.TwitchAPIHandler;

            var limit = user.ReadInput("Enter Limit").AsInt;
            var offset = user.ReadInput("Enter Offset").AsInt;
            var topGames = handler.API.V5.Games.GetTopGames(limit, offset);

            user.SendMessageAsReflection("TopGames", topGames);
        }

    }

}
