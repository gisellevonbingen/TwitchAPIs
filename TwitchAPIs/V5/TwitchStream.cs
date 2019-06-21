using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.V5
{
    public class TwitchStream
    {
        public string Id { get; set; }
        public string Game { get; set; }
        public int Viewers { get; set; }
        public int VideoHeight { get; set; }
        public int AverageFps { get; set; }
        public int Delay { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsPlaylist { get; set; }
        public TwitchImageSet Preview { get; set; }
        public TwitchChannel Channel { get; set; }

        public TwitchStream()
        {

        }

        public TwitchStream(JToken jToken)
        {
            this.Id = jToken.Value<string>("_id");
            this.Game = jToken.Value<string>("game");
            this.Viewers = jToken.Value<int>("viewers");
            this.VideoHeight = jToken.Value<int>("video_height");
            this.AverageFps = jToken.Value<int>("average_fps");
            this.Delay = jToken.Value<int>("delay");
            this.CreatedAt = jToken.Value<DateTime>("created_at");
            this.IsPlaylist = jToken.Value<bool>("is_playlist");
            this.Preview = jToken.ReadIfExist("preview", t => new TwitchImageSet(t));
            this.Channel = jToken.ReadIfExist("channel", t => new TwitchChannel(t));
        }

    }

}
