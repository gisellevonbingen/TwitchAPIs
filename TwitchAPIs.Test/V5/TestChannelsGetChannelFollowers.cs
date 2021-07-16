using Giselle.Commons;
using Giselle.Commons.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TwitchAPIs.V5;

namespace TwitchAPIs.Test.V5
{
    [TwitchAPITest("V5", "Channels")]
    public class TestChannelsGetChannelFollowers : TestAbstract
    {
        public TestChannelsGetChannelFollowers()
        {

        }

        public override void Run(TestMain main)
        {
            var user = main.User;
            var handler = main.TwitchAPIHandler;

            var channelId = user.ReadInput("Enter Channel Id").AsString;
            var limit = user.ReadInput("Enter Limit as int").AsInt;
            var offset = user.ReadInput("Enter Offset as int").AsInt;
            var direction = user.QueryInput("Enter Direction", SortDirection.Tags, null, true).Value;

            string cursor = null;

            while (true)
            {
                var channelFollowers = handler.API.V5.Channels.GetChannelFollowers(channelId, limit, offset, cursor, direction);
                user.SendMessageAsReflection("ChannelFollowers", channelFollowers);

                offset = null;
                cursor = channelFollowers.Cursor;

                if (string.IsNullOrWhiteSpace(cursor) == true)
                {
                    break;
                }

                Thread.Sleep(1000);
            }

        }

    }

}
