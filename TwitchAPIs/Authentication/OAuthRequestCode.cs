using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.Authentication
{
    public abstract class OAuthRequestCode : OAuthRequest
    {
        public string RedirectURI { get; set; }
        public bool? ForceVerify { get; set; }
        public string State { get; set; }

        public abstract string ResponseType { get; }
    }

}
