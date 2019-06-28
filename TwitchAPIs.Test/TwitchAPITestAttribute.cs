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
        public string[] Steps { get; }

        public TwitchAPITestAttribute(params string[] steps)
        {
            this.Steps = steps;
        }

    }

}
