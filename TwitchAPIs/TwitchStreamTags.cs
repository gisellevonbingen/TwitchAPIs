using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs
{
    public class TwitchStreamTags
    {
        public TwitchStreamTag[] Tags { get; set; }
        public string Cursor { get; set; }

        public TwitchStreamTags()
        {

        }

    }

}
