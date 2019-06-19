using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.New
{
    public class TwitchAPINew
    {
        public TwitchAPIClips Clips { get; }
        public TwitchAPIGames Games { get; }
        public TwitchAPITags Tags { get; }
        public TwitchAPIUsers Users { get; }

        public TwitchAPINew(TwitchAPI parent)
        {
            this.Clips = new TwitchAPIClips(parent);
            this.Games = new TwitchAPIGames(parent);
            this.Tags = new TwitchAPITags(parent);
            this.Users = new TwitchAPIUsers(parent);
        }

    }

}
