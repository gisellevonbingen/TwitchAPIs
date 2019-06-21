using Giselle.Commons;
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

            int? limit = NumberUtils.ToIntNullable(user.ReadInput("Enter Limit"));
            int? offset = NumberUtils.ToIntNullable(user.ReadInput("Enter Offset"));

            var topGames = handler.API.V5.Games.GetTopGames(limit, offset);
            user.SendMessageAsReflection($"Twitch Top Games", topGames);
        }

    }

}
