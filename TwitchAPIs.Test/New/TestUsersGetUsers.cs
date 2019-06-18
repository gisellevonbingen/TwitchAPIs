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
            var userTypes = (UserType[])Enum.GetValues(typeof(UserType));

            while (true)
            {
                var typeIndex = user.QueryInput("Enter UserType", userTypes.Select(v => v.ToString()), true).Index;

                if (typeIndex == -1)
                {
                    break;
                }

                var request = new UserRequest();
                request.Type = userTypes[typeIndex];
                request.Value = user.ReadInput("Enter User" + request.Type);

                requests.Add(request);
            }

            var api = handler.API;
            var tusers = api.New.Users.GetUsers(requests);
            main.PrintReflection(user, $"TwitchUsers", tusers);
        }

    }

}
