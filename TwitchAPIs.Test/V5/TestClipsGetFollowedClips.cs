using Giselle.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.Test.V5
{
    [TwitchAPITest("V5", "Clips")]
    public class TestClipsGetFollowedClips : TestAbstract
    {
        public TestClipsGetFollowedClips()
        {

        }

        public override void Run(TestMain main)
        {
            var user = main.User;
            var handler = main.TwitchAPIHandler;

            var limit = NumberUtils.ToLongNullable(user.ReadInput("Enter Limit as long"));
            var trending = NumberUtils.ToBoolNullable(user.ReadInput("Enter Trending as bool"));

            string cursor = null;

            while (true)
            {
                var clips = handler.API.V5.Clips.GetFollowedClips(limit, cursor, trending);
                cursor = clips.Cursor;
                main.PrintReflection(user, "TwitchFollowedClips", clips);

                if (string.IsNullOrWhiteSpace(cursor) == true || user.ReadBreak() == true)
                {
                    break;
                }

            }

        }

    }

}
