using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.Test
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class TwitchAPITestAttribute : Attribute
    {
        public string Version { get; }
        public string Resource { get; }

        public TwitchAPITestAttribute(string version, string resource)
        {
            this.Version = version;
            this.Resource = resource;
        }

    }

}
