using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.Authentication
{
    public abstract class OAuthRequest
    {
        public static string ScopeSeparater { get; } = " ";

        public List<string> Scopes { get;  }

        public OAuthRequest()
        {
            this.Scopes = new List<string>();
        }

    }

}
