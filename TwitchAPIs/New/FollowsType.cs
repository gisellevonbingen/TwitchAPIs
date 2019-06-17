using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.New
{
    public class FollowsType
    {
        /// <summary>
        /// XXX followed from id, Followings
        /// </summary>
        public static FollowsType From { get; } = new FollowsType("from", "to");
        /// <summary>
        /// XXX follow to id, Followers
        /// </summary>
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
