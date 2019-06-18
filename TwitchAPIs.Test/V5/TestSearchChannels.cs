using Giselle.Commons;
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

            string query = user.ReadInput("Enter Query");
            int? limit = NumberUtils.ToIntNullable(user.ReadInput("Enter Limit"));
            int? offset = NumberUtils.ToIntNullable(user.ReadInput("Enter Offset"));

            var channels = handler.API.V5.Search.SearchChannels(query, limit, offset);
            main.PrintReflection(user, $"TwitchChannels", channels);
        }

    }

}
