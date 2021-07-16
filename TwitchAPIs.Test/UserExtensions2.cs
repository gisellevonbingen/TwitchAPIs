using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Giselle.Commons.Users;

namespace TwitchAPIs.Test
{
    public static class UserExtensions2
    {
        public static List<string> ReadInputWhileBreakAsString(this UserAbstract user, string message)
        {
            return user.ReadInputWhileBreak(message, (u, t) => t.AsString);
        }

    }

}
