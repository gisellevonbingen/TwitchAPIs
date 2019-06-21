using Giselle.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.Test.V5
{
    [TwitchAPITest("V5", "Streams")]
    public class TestStreamsGetFeaturedStreams : TestAbstract
    {
        public TestStreamsGetFeaturedStreams()
        {

        }

        public override void Run(TestMain main)
        {
            var user = main.User;
            var handler = main.TwitchAPIHandler;

            var limit = NumberUtils.ToIntNullable(user.ReadInput("Enter Limit as int"));
            var offset = NumberUtils.ToIntNullable(user.ReadInput("Enter Offset as int"));
            var featuredStreams = handler.API.V5.Streams.GetFeaturedStreams(limit, offset);

            user.SendMessageAsReflection("TwitchFeaturedStreams", featuredStreams);
        }

    }

}
