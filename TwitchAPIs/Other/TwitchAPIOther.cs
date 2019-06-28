using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitchAPIs.Other.BadgesTwitchTVs;
using TwitchAPIs.Other.CbenniAPIs;
using TwitchAPIs.Other.TwitchEmotesAPIs;

namespace TwitchAPIs.Other
{
    public class TwitchAPIOther : TwitchAPIPart
    {
        public BadgesTwitchTV BadgesTwitchTV { get; }
        public CbenniAPI CbenniAPI { get; }
        public TwitchEmotesAPI TwitchEmotesAPI { get; }

        public TwitchAPIOther(TwitchAPI parent) : base(parent)
        {
            this.BadgesTwitchTV = new BadgesTwitchTV(parent);
            this.CbenniAPI = new CbenniAPI(parent);
            this.TwitchEmotesAPI = new TwitchEmotesAPI(parent);
        }

    }

}
