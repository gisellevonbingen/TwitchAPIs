﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.Test.New
{
    [TwitchAPITest("New", "Tags")]
    public class TestTagsReplaceStreamTags : TestAbstract
    {
        public TestTagsReplaceStreamTags()
        {
        }

        public override void Run(TestMain main)
        {
            var user = main.User;
            var handler = main.TwitchAPIHandler;

            var broadcasterId = user.ReadInput("Enter Broadcaster Id").AsString;
            var tagsId = user.ReadInputWhileBreakAsString("Enter Tag Id");
            handler.API.New.Tags.ReplaceStreamTags(broadcasterId, tagsId);
        }

    }

}
