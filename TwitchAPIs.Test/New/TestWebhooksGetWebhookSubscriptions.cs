﻿using Giselle.Commons;
using Giselle.Commons.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.Test.New
{
    [TwitchAPITest("New", "Webhooks")]
    public class TestWebhooksGetWebhookSubscriptions : TestAbstract
    {
        public TestWebhooksGetWebhookSubscriptions()
        {

        }

        public override void Run(TestMain main)
        {
            var user = main.User;
            var handler = main.TwitchAPIHandler;

            var first = user.ReadInput("Enter First as int").AsInt;
            string after = null;

            while (true)
            {
                var subscriptions = handler.API.New.Webhooks.GetWebhookSubscriptions(after, first);
                after = subscriptions.Pagination?.Cursor;
                user.SendMessageAsReflection("WebhookSubscriptions", subscriptions);

                if (string.IsNullOrWhiteSpace(after) == true || user.ReadBreak() == true)
                {
                    break;
                }

            }

        }

    }

}
