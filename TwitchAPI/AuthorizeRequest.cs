﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPI
{
    public class AuthorizeRequest
    {
        public string RedirectURI { get; set; }
        public string Scope { get; set; }
        public bool ForceVerify { get; set; }
        public string State { get; set; }
    }

}
