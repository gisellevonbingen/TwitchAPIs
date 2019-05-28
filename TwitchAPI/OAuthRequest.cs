using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs
{
    public abstract class OAuthRequest
    {
        public string RedirectURI { get; set; }
        public string Scope { get; set; }
        public bool ForceVerify { get; set; }
        public string State { get; set; }

        public abstract string ResponseType { get; }
    }

}
