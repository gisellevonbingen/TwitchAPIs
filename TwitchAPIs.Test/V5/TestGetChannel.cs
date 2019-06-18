using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitchAPIs.V5;

namespace TwitchAPIs.Test.V5
{
    [TwitchAPITest("V5", "Channels")]
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
                channel = api.V5.Channels.GetChannel();
            }
            else
            {
                channel = api.V5.Channels.GetChannel(id);
            }

            main.PrintReflection(user, "TwitchChannel", channel);
        }

    }

}
