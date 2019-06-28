using Giselle.Commons.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.Other
{
    public class CbenniAPI : TwitchAPIPart
    {
        public CbenniAPI(TwitchAPI parent) : base(parent)
        {

        }

        public TwitchBadgeSet GetBadges(string channelName)
        {
            var req = new WebRequestParameter();
            req.Uri = $"https://cbenni.com/api/badges/{channelName}";
            req.Method = "GET";

            using (var res = this.Parent.Web.Request(req))
            {
                return new TwitchBadgeSet(res.ReadAsJson());
            }

        }

    }

}
