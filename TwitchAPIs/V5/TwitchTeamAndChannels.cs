using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace TwitchAPIs.V5
{
    public class TwitchTeamAndChannels : TwitchTeam
    {
        public TwitchChannel[] Channels { get; set; }

        public TwitchTeamAndChannels()
        {

        }

        public TwitchTeamAndChannels(JToken jToken) : base(jToken)
        {
            this.Channels = jToken.ReadArray("users", t => new TwitchChannel(t));
        }

    }

}
