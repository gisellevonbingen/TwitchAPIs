using Giselle.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitchAPIs.V5;

namespace TwitchAPIs.Test.V5
{
    [TwitchAPITest("V5", "Streams")]
    public class TestStreamsGetLiveStreams : TestAbstract
    {
        public TestStreamsGetLiveStreams()
        {
        }

        public override void Run(TestMain main)
        {
            var user = main.User;
            var handler = main.TwitchAPIHandler;

            var options = new TwitchGetLiveStreamsOptions();
            options.Channels.AddRange(user.ReadInputWhileBreak("Enter ChannelId"));
            options.Game = user.ReadInput("Enter Game").AsString;
            options.Language = user.ReadInput("Enter Language").AsString;
            options.StreamType = user.QueryInput("Enter StremType", StreamType.Register, null, true).Value;
            options.Limit = user.ReadInput("Enter Limit as int").AsInt;
            options.Offset = user.ReadInput("Enter Offset as int").AsInt;
            var liveStreams = handler.API.V5.Streams.GetLiveStreams(options);

            user.SendMessageAsReflection("LiveStreams", liveStreams);
        }

    }

}
