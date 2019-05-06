using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace TwitchAPI
{
    public class TwitchFollowers
    {
        public int Total { get; set; }
        public string Cursor { get; set; }
        public List<TwitchFollower> Followers { get; }

        public TwitchFollowers()
        {
            this.Followers = new List<TwitchFollower>();
        }

    }

}
