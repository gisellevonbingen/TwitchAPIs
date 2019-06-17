using Giselle.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TwitchAPIs.Test
{
    public class TestGetAllStreamTags : TestAbstract
    {
        public TestGetAllStreamTags()
        {

        }

        public override void Run(TestMain main)
        {
            var user = main.User;
            var handler = main.TwitchAPIHandler;

            var first = NumberUtils.ToIntNullable(user.ReadInput("Enter First as int"));
            var tagIds = new List<string>();

            while (true)
            {
                var item = user.ReadInput("Enter TagId (Emtpy is break)");

                if (string.IsNullOrWhiteSpace(item) == true)
                {
                    break;
                }

                tagIds.Add(item);
            }

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

                cursor = tags.Cursor;

                if (cursor == null)
                {
                    break;
                }

                Thread.Sleep(1000);
            }

        }

    }

}
