using Giselle.Commons;
using Giselle.Commons.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitchAPIs.V5;

namespace TwitchAPIs.Test.V5
{
    [TwitchAPITest("V5", "Channels")]
    public class TestChannelsGetChannelSubscribers : TestAbstract
    {
        public TestChannelsGetChannelSubscribers()
        {

        }

        public override void Run(TestMain main)
        {
            var user = main.User;
            var handler = main.TwitchAPIHandler;

            var channelId = user.ReadInput("Enter Channels").AsString;
            var limit = user.ReadInput("Enter Limit as int").AsInt;
            var offset = user.ReadInput("Enter Offset as int").AsInt;
            var direction = user.QueryInput("Enter Direction", SortDirection.Tags, null, true).Value;
            var channelSubscriptions = handler.API.V5.Channels.GetChannelSubscribers(channelId, limit, offset, direction);

            user.SendMessageAsReflection("ChannelSubscriptions", channelSubscriptions);
        }

    }

}
