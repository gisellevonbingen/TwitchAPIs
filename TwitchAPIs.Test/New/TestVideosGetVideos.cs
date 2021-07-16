﻿using Giselle.Commons;
using Giselle.Commons.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitchAPIs.New;

namespace TwitchAPIs.Test.New
{
    [TwitchAPITest("New", "Videos")]
    public class TestVideosGetVideos : TestAbstract
    {
        public TestVideosGetVideos()
        {

        }

        public override void Run(TestMain main)
        {
            var user = main.User;
            var handler = main.TwitchAPIHandler;

            var options = new TwitchGetVideosOptions();
            options.Ids.AddRange(user.ReadInputWhileBreakAsString("Enter Id"));
            options.UserId = user.ReadInput("Enter User Id").AsString;
            options.GameId = user.ReadInput("Enter Game Id").AsString;

            options.First = user.ReadInput("Enter First as int").AsInt;
            options.Language = user.ReadInput("Enter Language").AsString;
            options.Period = user.QueryInput("Enter Period", GetVideoOptionsPeriod.Tags, null, true).Value;
            options.Sort = user.QueryInput("Enter Sort", GetVideoOptionsSort.Tags, null, true).Value;
            options.Type = user.QueryInput("Enter Type", GetVideoOptionsType.Tags, null, true).Value;

            while (true)
            {
                var videos = handler.API.New.Videos.GetVideos(options);
                user.SendMessageAsReflection("Videos", videos);

                options.After = null;
                options.Before = null;
                var index = user.QueryInput("Select Direction", new string[] { "after", "before" }, null, true).Index;

                if (index == -1)
                {
                    break;
                }
                else if (index == 0)
                {
                    options.After = videos.Pagination.Cursor;
                }
                else
                {
                    options.Before = videos.Pagination.Cursor;
                }

            }

        }

    }

}
