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
        public TwitchAPIStreams Streams { get; }
        public TwitchAPITags Tags { get; }
        public TwitchAPIUsers Users { get; }
        public TwitchAPIVideos Videos { get; }
        public TwitchAPIWebhooks Webhooks { get; }

        public TwitchAPINew(TwitchAPI parent)
        {
            this.Clips = new TwitchAPIClips(parent);
            this.Games = new TwitchAPIGames(parent);
            this.Streams = new TwitchAPIStreams(parent);
            this.Tags = new TwitchAPITags(parent);
            this.Users = new TwitchAPIUsers(parent);
            this.Videos = new TwitchAPIVideos(parent);
            this.Webhooks = new TwitchAPIWebhooks(parent);
        }

    }

}
