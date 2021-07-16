using Giselle.Commons.Users;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitchAPIs.Other;

namespace TwitchAPIs.Test.Other
{
    [TwitchAPITest("Other", "BadgesTwitchTV")]
    public class TestBadgesTwitchTVGetGlobalBadges : TestAbstract
    {
        public TestBadgesTwitchTVGetGlobalBadges()
        {

        }

        public override void Run(TestMain main)
        {
            var user = main.User;
            var handler = main.TwitchAPIHandler;

            var set = handler.API.Other.BadgesTwitchTV.GetGlobalBadges();

            user.SendMessageAsReflection("Badges", set);
        }

    }

}
