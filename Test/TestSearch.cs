using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPI.Test
{
    public class TestSearch : TestAbstract
    {
        public TestSearch()
        {

        }

        public override void Run(TestMain main)
        {
            var user = main.User;
            var handler = main.TwitchAPIHandler;

            var methods = new List<Tuple<string, Action<TestMain>>>();
            methods.Add(new Tuple<string, Action<TestMain>>(nameof(this.TestChannels), this.TestChannels));

            var index = user.QueryInput("Enter SearchType", methods.Select(t => t.Item1));
            var tuple = methods[index];

            tuple.Item2(main);
        }

        public void TestChannels(TestMain main)
        {
            var user = main.User;
            var handler = main.TwitchAPIHandler;

            string query = user.ReadInput("Enter Query");
            int? limit = NumberUtils.ToIntNullable(user.ReadInput("Enter Limit"));
            int? offset = NumberUtils.ToIntNullable(user.ReadInput("Enter Offset"));

            var channels = handler.API.Search.SearchChannels(query, limit, offset);
            user.SendMessage("Channels Count : " + channels.Length);

            for (int i = 0; i < channels.Length; i++)
            {
                var channel = channels[i];
                main.PrintReflection(user, $"{i} / {channels.Length}", channel);
            }

        }

    }

}
