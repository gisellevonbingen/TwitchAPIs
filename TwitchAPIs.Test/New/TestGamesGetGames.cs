﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Giselle.Commons.Users;

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

            var id = user.ReadInput("Enter Id").AsString;
            var name = user.ReadInput("Enter Name").AsString;
            var games = handler.API.New.Games.GetGames(id, name);

            user.SendMessageAsReflection("Games", games);
        }

    }

}
