using Giselle.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TwitchAPIs.Test.New
{
    [TwitchAPITest("New", "Tags")]
    public class TestTagsGetAllStreamTags : TestAbstract
    {
        public TestTagsGetAllStreamTags()
        {

        }

        public override void Run(TestMain main)
        {
            var user = main.User;
            var handler = main.TwitchAPIHandler;

            var first = user.ReadInput("Enter First as int").AsInt;
            var tagIds = new List<string>(user.ReadInputWhileBreak("Enter Tag Id"));

            string cursor = null;

            while (true)
            {
                var tags = handler.API.New.Tags.GetAllStreamTags(cursor, first, tagIds);

                foreach (var tag in tags.Tags)
                {
                    user.SendMessage();
                    user.SendMessage($"Id={tag.Id}");
                    user.SendMessage($"    IsAuto={tag.IsAuto}");
                    user.SendMessage($"    Name={(tag.LocalizationNames.TryGetValue("ko-kr", out var name) ? name : null)}");
                    user.SendMessage($"    Description={(tag.LocalizationDescriptions.TryGetValue("ko-kr", out var description) ? description : null)}");
                }

                cursor = tags.Pagination.Cursor;

                if (string.IsNullOrWhiteSpace(cursor) == true)
                {
                    break;
                }

                Thread.Sleep(1000);
            }

        }

    }

}
