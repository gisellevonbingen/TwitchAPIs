using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs
{
    public class TwitchAPIRequestParameter
    {
        public APIVersion? Version { get; set; }
        public string BaseURL { get; set; }
        public string Path { get; set; }
        public Dictionary<string, string> QueryValues { get; set; }
        public string Method { get; set; }

        public TwitchAPIRequestParameter()
        {

        }

    }

}
