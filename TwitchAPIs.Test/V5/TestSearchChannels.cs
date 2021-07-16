using Giselle.Commons;
using Giselle.Commons.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.Test.V5
{
    [TwitchAPITest("V5", "Search")]
    public class TestSearchChannels : TestAbstract
    {
        public TestSearchChannels()
        {

        }

        public override void Run(TestMain main)
        {
            var user = main.User;
            var handler = main.TwitchAPIHandler;

            var query = user.ReadInput("Enter Query").AsString;
            var limit = user.ReadInput("Enter Limit").AsInt;
            var offset = user.ReadInput("Enter Offset").AsInt;
            var channels = handler.API.V5.Search.SearchChannels(query, limit, offset);

            user.SendMessageAsReflection("Channels", channels);
        }

    }

}
