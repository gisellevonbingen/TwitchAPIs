using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.New
{
    public class TwitchAPINew
    {
        public TwitchAPIUsers Users { get; }
        public TwitchAPIGames Games { get; }
        public TwitchAPIClips Clips { get; }
        public TwitchAPITags Tags { get; }

        public TwitchAPINew(TwitchAPI parent)
        {
            this.Users = new TwitchAPIUsers(parent);
            this.Games = new TwitchAPIGames(parent);
            this.Clips = new TwitchAPIClips(parent);
            this.Tags = new TwitchAPITags(parent);
        }

    }

}
