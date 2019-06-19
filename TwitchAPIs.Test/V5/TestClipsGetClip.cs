using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.Test.V5
{
    [TwitchAPITest("V5", "Clips")]
    public class TestClipsGetClip : TestAbstract
    {
        public TestClipsGetClip()
        {
        }

        public override void Run(TestMain main)
        {
            var user = main.User;
            var handler = main.TwitchAPIHandler;

            var slug = user.ReadInput("Enter Slug");
            var clip = handler.API.V5.Clips.GetClip(slug);

            main.PrintReflection(user, "TwitchClip", clip);
        }

    }

}
