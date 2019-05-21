using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPI
{
    public class FollowsType
    {
        public static FollowsType From { get; } = new FollowsType("from", "to");
        public static FollowsType To { get; } = new FollowsType("to", "from");

        public string Request { get; }
        public string Response { get; }

        public FollowsType(string request, string response)
        {
            Request = request;
            Response = response;
        }

    }

}
