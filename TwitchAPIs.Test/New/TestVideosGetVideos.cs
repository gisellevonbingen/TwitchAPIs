using Giselle.Commons;
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
            options.Ids.AddRange(user.ReadInputWhileBreak("Enter Id"));
            options.UserId = user.ReadInput("Enter User Id");
            options.GameId = user.ReadInput("Enter Game Id");

            options.First = NumberUtils.ToIntNullable(user.ReadInput("Enter First as int"));
            options.Language = user.ReadInput("Enter Language");
            options.Period = user.QueryInput("Enter Period", GetVideoOptionsPeriod.Register, null, true).Value;
            options.Sort = user.QueryInput("Enter Sort", GetVideoOptionsSort.Register, null, true).Value;
            options.Type = user.QueryInput("Enter Type", GetVideoOptionsType.Register, null, true).Value;

            while (true)
            {
                var videos = handler.API.New.Videos.GetVideos(options);
                user.SendMessageAsReflection("TwitchVideos", videos);

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
