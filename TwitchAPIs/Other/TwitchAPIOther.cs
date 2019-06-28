using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.Other
{
    public class TwitchAPIOther : TwitchAPIPart
    {
        public BadgesTwitchTV BadgesTwitchTV { get; }
        public CbenniAPI CbenniAPI { get; }

        public TwitchAPIOther(TwitchAPI parent) : base(parent)
        {
            this.BadgesTwitchTV = new BadgesTwitchTV(parent);
            this.CbenniAPI = new CbenniAPI(parent);
        }

    }

}
