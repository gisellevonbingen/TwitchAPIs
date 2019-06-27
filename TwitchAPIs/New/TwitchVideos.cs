using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.New
{
    public class TwitchVideos
    {
        public TwitchVideo[] Videos { get; set; }
        public Pagination Pagination { get; set; }

        public TwitchVideos()
        {

        }

        public TwitchVideos(JToken jToken)
        {
            this.Videos = jToken.ReadArray("data", t => new TwitchVideo(t));
            this.Pagination = jToken.ReadIfExist("pagination", t => new Pagination(t));
        }

    }

}
