using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitchAPIs.New;

namespace TwitchAPIs.Test.New
{
    [TwitchAPITest("New", "Users")]
    public class TestUsersGetUsers : TestAbstract
    {
        public TestUsersGetUsers()
        {

        }

        public override void Run(TestMain main)
        {
            var user = main.User;
            var handler = main.TwitchAPIHandler;

            var requests = new List<UserRequest>();

            while (true)
            {
                var typeInput = user.QueryInput("Enter UserType", UserRequestType.Register, null, true);

                if (typeInput.Breaked == true)
                {
                    break;
                }

                var request = new UserRequest();
                request.Type = typeInput.Value;
                request.Value = user.ReadInput("Enter User" + request.Type);

                requests.Add(request);
            }

            var api = handler.API;
            var tusers = api.New.Users.GetUsers(requests);
            user.SendMessageAsReflection($"TwitchUsers", tusers);
        }

    }

}
