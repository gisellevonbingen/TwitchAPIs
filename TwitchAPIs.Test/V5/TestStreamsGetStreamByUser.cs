using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitchAPIs.V5;

namespace TwitchAPIs.Test.V5
{
    [TwitchAPITest("V5", "Streams")]
    public class TestStreamsGetStreamByUser : TestAbstract
    {
        public TestStreamsGetStreamByUser()
        {

        }

        public override void Run(TestMain main)
        {
            var user = main.User;
            var handler = main.TwitchAPIHandler;

            var channelId = user.ReadInput("Enter Channel Id");
            var type = user.QueryInput("Enter StremType", EnumUtils.GetNullableValues<StreamType>(), null, true).Value;
            var stream = handler.API.V5.Streams.GetStreamByUser(channelId, type);

            main.PrintReflection(user, "TwitchStream", stream);
        }

    }

}
