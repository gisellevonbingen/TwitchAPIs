using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.Test.Other
{
    [TwitchAPITest("Other", "CbenniAPI")]
    public class TestCbenniAPIGetBadges : TestAbstract
    {
        public TestCbenniAPIGetBadges()
        {

        }

        public override void Run(TestMain main)
        {
            var user = main.User;
            var handler = main.TwitchAPIHandler;

            var channelName = user.ReadInput("Enter Channel Name").AsString;
            var set = handler.API.Other.CbenniAPI.GetBadges(channelName);

            user.SendMessageAsReflection("Badges", set);
        }

    }

}
