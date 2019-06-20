using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.Authentication
{
    public class OAuthRequestAuthorizationCode : OAuthRequestCode
    {
        public string ClientSecret { get; set; }
        public override string ResponseType => OAuthResponseType.Authorization;
    }

}
