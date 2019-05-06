using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace TwitchAPI
{
    public class TwitchUser
    {
        public string Id { get; set; }
        public string Login { get; set; }
        public string DisplayName { get; set; }

        public TwitchUser()
        {

        }

    }

}
