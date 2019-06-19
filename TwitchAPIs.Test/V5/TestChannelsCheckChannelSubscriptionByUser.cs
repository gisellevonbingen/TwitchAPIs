﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.Test.V5
{
    [TwitchAPITest("V5", "Channels")]
    public class TestChannelsCheckChannelSubscriptionByUser : TestAbstract
    {
        public TestChannelsCheckChannelSubscriptionByUser()
        {

        }

        public override void Run(TestMain main)
        {
            var user = main.User;
            var handler = main.TwitchAPIHandler;

            var api = handler.API;
            var channelId = user.ReadInput("Enter Channel Id");
            var userId = user.ReadInput("Enter User Id");
            var subscription = api.V5.Channels.CheckChannelSubscriptionByUser(channelId, userId);

            main.PrintReflection(user, "TwitchChannelSubscription", subscription);
        }

    }

}