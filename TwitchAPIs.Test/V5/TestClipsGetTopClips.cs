﻿using Giselle.Commons;
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
            options.Channel = user.ReadInput("Enter Channel");
            options.Game = user.ReadInput("Enter Game");

            while (true)
            {
                var language = user.ReadInput("Enter Language, breakable");

                if (user.IsBreak(language) == true)
                {
                    break;
                }

                options.Languages.Add(language);
            }

            options.Limit = NumberUtils.ToLongNullable(user.ReadInput("Enter Limit as long"));
            options.Period = user.QueryInput("Enter Channel", EnumUtils.GetNullableValues<GetTopClipsPeriod>(), null, true).Value;
            options.Trending = NumberUtils.ToBoolNullable(user.ReadInput("Enter Trending as bool"));

            while (true)
            {
                var clips = handler.API.V5.Clips.GetTopClips(options);
                options.Cursor = clips.Cursor;

                main.PrintReflection(user, "TwitchTopClips", clips);

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