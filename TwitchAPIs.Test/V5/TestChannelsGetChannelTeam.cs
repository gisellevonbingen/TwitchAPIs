﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Giselle.Commons.Users;

namespace TwitchAPIs.Test.V5
{
    [TwitchAPITest("V5", "Channels")]
    public class TestChannelsGetChannelTeam : TestAbstract
    {
        public TestChannelsGetChannelTeam()
        {

        }

        public override void Run(TestMain main)
        {
            var user = main.User;
            var handler = main.TwitchAPIHandler;

            var channelId = user.ReadInput("Enter Channel Id").AsString;
            var teams = handler.API.V5.Channels.GetChannelTeams(channelId);

            user.SendMessageAsReflection("Teams", teams);
        }

    }

}
