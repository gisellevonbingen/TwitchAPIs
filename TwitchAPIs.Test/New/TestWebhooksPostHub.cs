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

            var callback = user.ReadInput("Enter Calllback").AsString;
            var mode = user.QueryInput("Enter Mode", HubMode.Register, null, true).Value;
            var topic = user.ReadInput("Enter Topic").AsString;
            var leaseSeconds = user.ReadInput("Enter Lease Seconds as int").AsInt;
            var secret = user.ReadInput("Enter Secret").AsString;

            var result = handler.API.New.Webhooks.PostHub(callback, mode, topic, leaseSeconds, secret);
            user.SendMessage(result);
        }

    }

}
