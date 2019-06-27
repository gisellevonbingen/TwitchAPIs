using Giselle.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitchAPIs.V5;

namespace TwitchAPIs.Test.V5
{
    [TwitchAPITest("V5", "Search")]
    public class TestSearchStreams : TestAbstract
    {
        public TestSearchStreams()
        {
        }

        public override void Run(TestMain main)
        {
            var user = main.User;
            var handler = main.TwitchAPIHandler;

            string query = user.ReadInput("Enter Query");
            int? limit = NumberUtils.ToIntNullable(user.ReadInput("Enter Limit"));
            int? offset = NumberUtils.ToIntNullable(user.ReadInput("Enter Offset"));
            var hlsMode = user.QueryInput("Enter HLS", HLSMode.Register, null, true).Value;

            var streams = handler.API.V5.Search.SearchStreams(query, limit, offset, hlsMode);
            user.SendMessageAsReflection($"TwitchSearchStreams", streams);
        }

    }

}
