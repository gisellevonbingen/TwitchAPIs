using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.Authentication
{
    public class OAuthRequestAuthorization : OAuthRequest
    {
        public string ClientSecret { get; set; }

        public OAuthRequestAuthorization()
        {

        }

        public override string ResponseType => OAuthResponseType.Authorization;
    }

}
