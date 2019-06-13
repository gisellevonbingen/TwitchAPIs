﻿using Giselle.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.Test
{
    public class TestGetTopGames : TestAbstract
    {
        public TestGetTopGames()
        {

        }

        public override void Run(TestMain main)
        {
            var user = main.User;
            var handler = main.TwitchAPIHandler;

            int? limit = NumberUtils.ToIntNullable(user.ReadInput("Enter Limit"));
            int? offset = NumberUtils.ToIntNullable(user.ReadInput("Enter Offset"));

            var topGames = handler.API.Games.GetTopGames(limit, offset);
            main.PrintReflection(user, $"Twitch Top Games", topGames);
        }

    }

}