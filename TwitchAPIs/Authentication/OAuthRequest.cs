﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.Authentication
{
    public abstract class OAuthRequest
    {
        public string Scope { get; set; }
    }

}