using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPI
{
    public class AccessTokenRequest
    {
        public string ClientSecret { get; set; }
        public string Code { get; set; }
        public string RedirectURI { get; set; }
    }

}
