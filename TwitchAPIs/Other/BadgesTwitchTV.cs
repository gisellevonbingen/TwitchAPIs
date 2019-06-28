using Giselle.Commons.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.Other
{
    public class BadgesTwitchTV : TwitchAPIPart
    {
        public BadgesTwitchTV(TwitchAPI parent) : base(parent)
        {

        }

        public TwitchBadgeSet GetGlobalBadges()
        {
            var req = new WebRequestParameter();
            req.Uri = $"https://badges.twitch.tv/v1/badges/global/display";
            req.Method = "GET";

            using (var res = this.Parent.Web.Request(req))
            {
                return new TwitchBadgeSet(res.ReadAsJson());
            }

        }

        public TwitchBadgeSet GetChannelBadges(string channelId)
        {
            var req = new WebRequestParameter();
            req.Uri = $"https://badges.twitch.tv/v1/badges/channels/{channelId}/display";
            req.Method = "GET";

            using (var res = this.Parent.Web.Request(req))
            {
                return new TwitchBadgeSet(res.ReadAsJson());
            }

        }

    }

}
