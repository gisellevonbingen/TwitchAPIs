using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.Authentication
{
    public class OAuthRequestClientCredentials : OAuthRequest
    {
        public string ClientSecret { get; set; }
    }

}
