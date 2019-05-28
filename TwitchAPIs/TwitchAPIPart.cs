using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs
{
    public abstract class TwitchAPIPart
    {
        protected TwitchAPI Parent { get; }

        public TwitchAPIPart(TwitchAPI parent)
        {
            this.Parent = parent;
        }

    }

}
