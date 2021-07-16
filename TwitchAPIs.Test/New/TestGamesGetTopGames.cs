using Giselle.Commons;
using Giselle.Commons.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.Test.New
{
    [TwitchAPITest("New", "Games")]
    public class TestGamesGetTopGames : TestAbstract
    {
        public TestGamesGetTopGames()
        {

        }

        public override void Run(TestMain main)
        {
            var user = main.User;
            var handler = main.TwitchAPIHandler;

            var first = user.ReadInput("Enter First as int").AsInt;

            string after = null;
            string before = null;

            while (true)
            {
                var topGames = handler.API.New.Games.GetTopGames(after, before, first);
                user.SendMessageAsReflection("TopGames", topGames);

                after = null;
                before = null;
                var index = user.QueryInput("Select Direction", new string[] { "after", "before" }, null, true).Index;

                if (index == -1)
                {
                    break;
                }
                else if (index == 0)
                {
                    after = topGames.Pagination.Cursor;
                }
                else
                {
                    before = topGames.Pagination.Cursor;
                }

            }

        }

    }

}
