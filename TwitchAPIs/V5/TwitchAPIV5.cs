using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.V5
{
    public class TwitchAPIV5
    {
        public TwitchAPIUsers Users { get; }
        public TwitchAPISearch Search { get; }
        public TwitchAPIChannels Channels { get; }
        public TwitchAPIGames Games { get; }
        public TwitchAPIChat Chat { get; }
        public TwitchAPIBits Bits { get; }
        public TwitchAPITeam Teams { get; }

        public TwitchAPIV5(TwitchAPI parent)
        {
            this.Users = new TwitchAPIUsers(parent);
            this.Search = new TwitchAPISearch(parent);
            this.Channels = new TwitchAPIChannels(parent);
            this.Games = new TwitchAPIGames(parent);
            this.Chat = new TwitchAPIChat(parent);
            this.Bits = new TwitchAPIBits(parent);
            this.Teams = new TwitchAPITeam(parent);
        }

    }

}
