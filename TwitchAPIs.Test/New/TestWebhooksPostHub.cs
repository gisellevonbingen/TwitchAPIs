using Giselle.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitchAPIs.New;

namespace TwitchAPIs.Test.New
{
    [TwitchAPITest("New", "Webhooks")]
    public class TestWebhooksPostHub : TestAbstract
    {
        public TestWebhooksPostHub()
        {

        }

        public override void Run(TestMain main)
        {
            var user = main.User;
            var handler = main.TwitchAPIHandler;

            var callback = user.ReadInput("Enter Calllback");
            var mode = user.QueryInput("Enter Mode", HubMode.Register, v => v.Name, true).Value;
            var topic = user.ReadInput("Enter Topic");
            var leaseSeconds = NumberUtils.ToIntNullable(user.ReadInput("Enter Lease Seconds as int"));
            var secret = user.ReadInput("Enter Secret");

            var result = handler.API.New.Webhooks.PostHub(callback, mode, topic, leaseSeconds, secret);
            user.SendMessage(result);
        }

    }

}
