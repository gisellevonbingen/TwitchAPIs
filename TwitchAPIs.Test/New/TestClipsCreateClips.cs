using Giselle.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.Test.New
{
    [TwitchAPITest("New", "Clips")]
    public class TestClipsCreateClips : TestAbstract
    {
        public TestClipsCreateClips()
        {

        }

        public override void Run(TestMain main)
        {
            var user = main.User;
            var handler = main.TwitchAPIHandler;

            var broadcasterId = user.ReadInput("Enter Broadcaster Id").AsString;
            var hasDelay = user.ReadInput("Enter Has Delay as bool").AsBool;
            var clipEdit = handler.API.New.Clips.CreateClip(broadcasterId, hasDelay);

            user.SendMessageAsReflection("TwitchClipEdit", clipEdit);
        }

    }

}
