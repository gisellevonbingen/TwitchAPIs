using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitchAPIs.Other;

namespace TwitchAPIs.Test.Other
{
    [TwitchAPITest("Other", "BadgesTwitchTV")]
    public class TestBadgesTwitchTVGetChannelBadges : TestAbstract
    {
        public TestBadgesTwitchTVGetChannelBadges()
        {

        }

        public override void Run(TestMain main)
        {
            var user = main.User;
            var handler = main.TwitchAPIHandler;

            var channelId = user.ReadInput("Channel Id").AsString;
            var set = handler.API.Other.BadgesTwitchTV.GetChannelBadges(channelId);

            user.SendMessageAsReflection("Badges", set);
        }

    }

}
