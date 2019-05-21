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
        public string BroadcasterType { get; set; }
        public string Description { get; set; }
        public string DisplayName { get; set; }
        public string Email { get; set; }
        public string Id { get; set; }
        public string Login { get; set; }
        public string OfflineImageUrl { get; set; }
        public string ProfileImageUrl { get; set; }
        public string Type { get; set; }
        public int ViewCount { get; set; }

        public TwitchUser()
        {

        }

    }

}
