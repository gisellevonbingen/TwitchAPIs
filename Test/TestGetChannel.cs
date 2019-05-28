using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.Test
{
    public class TestGetChannel : TestAbstract
    {
        public TestGetChannel()
        {

        }

        public override void Run(TestMain main)
        {
            var user = main.User;
            var handler = main.TwitchAPIHandler;

            var api = handler.API;
            var id = user.ReadInput("Enter Channel Id (Emtpy is own)");
            TwitchChannel channel = null;

            if (string.IsNullOrWhiteSpace(id) == true)
            {
                channel = api.Channels.GetChannel();
            }
            else
            {
                channel = api.Channels.GetChannel(id);
            }

            main.PrintReflection(user, "TwitchChannel", channel);
        }

    }

}
