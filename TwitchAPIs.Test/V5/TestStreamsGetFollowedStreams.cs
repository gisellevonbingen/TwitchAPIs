using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.Test.V5
{
    [TwitchAPITest("V5", "Streams")]
    public class TestStreamsGetFollowedStreams : TestAbstract
    {
        public TestStreamsGetFollowedStreams()
        {

        }

        public override void Run(TestMain main)
        {
            var user = main.User;
            var handler = main.TwitchAPIHandler;

            var followedStreams = handler.API.V5.Streams.GetFollowedStreams();

            user.SendMessageAsReflection("FollowedStreams", followedStreams);
        }

    }

}
