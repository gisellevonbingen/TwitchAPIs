using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPI.Test
{
    public class TestGetUser : TestAbstract
    {
        public TestGetUser()
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
                var typeIndex = user.QueryInput("Enter UserType", userTypes.Select(v => v.ToString()), true);

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
            var tusers = api.User.GetUsers(requests);
            main.PrintReflection(user, $"TwitchUsers", tusers);
        }

    }

}
