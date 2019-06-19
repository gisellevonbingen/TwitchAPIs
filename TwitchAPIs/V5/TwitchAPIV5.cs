using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.V5
{
    public class TwitchAPIV5
    {
        public TwitchAPIBits Bits { get; }
        public TwitchAPIChannels Channels { get; }
        public TwitchAPIChat Chat { get; }
        public TwitchAPIClips Clips { get; }
        public TwitchAPIGames Games { get; }
        public TwitchAPISearch Search { get; }
        public TwitchAPITeam Teams { get; }
        public TwitchAPIUsers Users { get; }

        public TwitchAPIV5(TwitchAPI parent)
        {
            this.Bits = new TwitchAPIBits(parent);
            this.Channels = new TwitchAPIChannels(parent);
            this.Chat = new TwitchAPIChat(parent);
            this.Clips = new TwitchAPIClips(parent);
            this.Games = new TwitchAPIGames(parent);
            this.Search = new TwitchAPISearch(parent);
            this.Teams = new TwitchAPITeam(parent);
            this.Users = new TwitchAPIUsers(parent);
        }

    }

}
