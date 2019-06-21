using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.Authentication
{
    public class OAuthTokenRequest
    {
        public string ClientSecret { get; set; }
        public string Code { get; set; }
        public string GrantType { get; set; }
        public string RedirectUri { get; set; }
        public List<string> Scopes { get; } = new List<string>();
    }

}
