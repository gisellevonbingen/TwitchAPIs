﻿using Giselle.Commons;
using Giselle.Commons.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitchAPIs.V5;

namespace TwitchAPIs.Test.V5
{
    [TwitchAPITest("V5", "Clips")]
    public class TestClipsGetTopClips : TestAbstract
    {
        public TestClipsGetTopClips()
        {

        }

        public override void Run(TestMain main)
        {
            var user = main.User;
            var handler = main.TwitchAPIHandler;

            var options = new TwitchGetTopClipsOptions();
            options.Channel = user.ReadInput("Enter Channel").AsString;
            options.Game = user.ReadInput("Enter Game").AsString;
            options.Languages.AddRange(user.ReadInputWhileBreakAsString("Enter Language"));
            options.Limit = user.ReadInput("Enter Limit as long").AsLong;
            options.Period = user.QueryInput("Enter Channel", TopClipsPeriod.Register, null, true).Value;
            options.Trending = user.ReadInput("Enter Trending as bool").AsBool;

            while (true)
            {
                var clips = handler.API.V5.Clips.GetTopClips(options);
                options.Cursor = clips.Cursor;

                user.SendMessageAsReflection("TopClips", clips);

                if (string.IsNullOrWhiteSpace(options.Cursor) == true)
                {
                    break;
                }
                else if (user.ReadBreak() == true)
                {
                    break;
                }

            }

        }

    }

}
