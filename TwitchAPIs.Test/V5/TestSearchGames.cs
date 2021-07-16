using Giselle.Commons;
using Giselle.Commons.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.Test.V5
{
    [TwitchAPITest("V5", "Search")]
    public class TestSearchGames : TestAbstract
    {
        public TestSearchGames()
        {

        }

        public override void Run(TestMain main)
        {
            var user = main.User;
            var handler = main.TwitchAPIHandler;

            var query = user.ReadInput("Enter Query").AsString;
            var live = user.ReadInput("Enter Live as bool").AsBool;
            var games = handler.API.V5.Search.SearchGames(query, live);

            user.SendMessageAsReflection("Games", games);
        }

    }

}
