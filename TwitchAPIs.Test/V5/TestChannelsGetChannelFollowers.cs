using Giselle.Commons;
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

        private Nullable<T> QueryEnum<T>(UserAbstract user, string message) where T : struct, Enum
        {
            var type = typeof(T);
            var values = Enum.GetValues(type) as T[];

            var index = user.QueryInput(message, values, true);

            if (index == -1)
            {
                return null;
            }
            else
            {
                return new Nullable<T>(values[index]);
            }

        }

        public override void Run(TestMain main)
        {
            var user = main.User;
            var handler = main.TwitchAPIHandler;

            var channelId = user.ReadInput("Enter Channel Id");
            var limit = NumberUtils.ToIntNullable(user.ReadInput("Enter Limit as int"));
            var offset = NumberUtils.ToIntNullable(user.ReadInput("Enter Offset as int"));
            var direction = this.QueryEnum<SortDirection>(user, "Enter Direction as int");

            string cursor = null;

            while (true)
            {
                var channelFollowers = handler.API.V5.Channels.GetChannelFollowers(channelId, limit, offset, cursor, direction);
                main.PrintReflection(user, "ChannelFollowers", channelFollowers);

                offset = null;
                cursor = channelFollowers.Cursor;

                if (cursor == null)
                {
                    break;
                }

                Thread.Sleep(1000);
            }

        }

    }

}
