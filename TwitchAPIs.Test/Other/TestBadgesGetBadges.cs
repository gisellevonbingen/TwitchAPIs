using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitchAPIs.Other;

namespace TwitchAPIs.Test.Other
{
    [TwitchAPITestAttribute("Other", "Badges")]
    public class TestBadgesGetBadges : TestAbstract
    {
        public TestBadgesGetBadges()
        {

        }

        public override void Run(TestMain main)
        {
            var user = main.User;
            var handler = main.TwitchAPIHandler;

            var channelId = user.ReadInput("Channel-Id(Empty is Global)");
            var badges = handler.API.Badges;
            TwitchBadgeSet set = null;

            if (string.IsNullOrWhiteSpace(channelId) == true)
            {
                set = badges.GetGlobalBadges();
            }
            else
            {
                set = badges.GetChannelBadges(channelId);
            }

            main.PrintReflection(user, $"{channelId}", set);

        }

    }

}
