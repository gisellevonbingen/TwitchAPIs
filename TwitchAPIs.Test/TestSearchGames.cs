using Giselle.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.Test
{
    public class TestSearchGames : TestAbstract
    {
        public TestSearchGames()
        {

        }

        public override void Run(TestMain main)
        {
            var user = main.User;
            var handler = main.TwitchAPIHandler;

            string query = user.ReadInput("Enter Query");
            bool? live = NumberUtils.ToBoolNullable(user.ReadInput("Enter Live"));

            var games = handler.API.V5.Search.SearchGames(query, live);
            main.PrintReflection(user, $"TwitchGames", games);
        }

    }

}
