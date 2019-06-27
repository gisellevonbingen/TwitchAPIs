using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.Test.New
{
    [TwitchAPITest("New", "Tags")]
    public class TestTagsGetStreamTags : TestAbstract
    {
        public TestTagsGetStreamTags()
        {

        }

        public override void Run(TestMain main)
        {
            var user = main.User;
            var handler = main.TwitchAPIHandler;

            var broadcasterId = user.ReadInput("Enter Broadcaster Id").AsString;
            var tags = handler.API.New.Tags.GetStreamTags(broadcasterId);

            foreach (var tag in tags)
            {
                user.SendMessage();
                user.SendMessage($"Id={tag.Id}");
                user.SendMessage($"    IsAuto={tag.IsAuto}");
                user.SendMessage($"    Name={(tag.LocalizationNames.TryGetValue("ko-kr", out var name) ? name : null)}");
                user.SendMessage($"    Description={(tag.LocalizationDescriptions.TryGetValue("ko-kr", out var description) ? description : null)}");
            }

        }

    }

}
