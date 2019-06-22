using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.New
{
    public class TwitchAllStreamTags
    {
        public TwitchStreamTag[] Tags { get; set; }
        public Pagination Pagination { get; set; }

        public TwitchAllStreamTags()
        {

        }

    }

}
