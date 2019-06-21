using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.Test.New
{
    [TwitchAPITest("New", "Games")]
    public class TestGamesGetGames : TestAbstract
    {
        public TestGamesGetGames()
        {

        }

        public override void Run(TestMain main)
        {
            var user = main.User;
            var handler = main.TwitchAPIHandler;

            var id = user.ReadInput("Enter Id");
            var name = user.ReadInput("Enter Name");

            var games = handler.API.New.Games.GetGames(id, name);

            user.SendMessageAsReflection("Games", games);
        }

    }

}
