using Giselle.Commons.Web;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.Other
{
    public class TwitchAPIBadges : TwitchAPIPart
    {
        public TwitchAPIBadges(TwitchAPI parent) : base(parent)
        {

        }

        public TwitchBadgeSet GetIntegrationBadges(string channelName)
        {
            var req = new WebRequestParameter();
            req.URL = $"https://cbenni.com/api/badges/{channelName}";
            req.Method = "GET";

            using (var res = this.Parent.Web.Request(req))
            {
                var set = new TwitchBadgeSet();
                set.Read(res.ReadAsJson());

                return set;
            }

        }

        public TwitchBadgeSet GetGlobalBadges()
        {
            var req = new WebRequestParameter();
            req.URL = $"https://badges.twitch.tv/v1/badges/global/display";
            req.Method = "GET";

            using (var res = this.Parent.Web.Request(req))
            {
                var set = new TwitchBadgeSet();
                set.Read(res.ReadAsJson());

                return set;
            }

        }

        public TwitchBadgeSet GetChannelBadges(string channelId)
        {
            var req = new WebRequestParameter();
            req.URL = $"https://badges.twitch.tv/v1/badges/channels/{channelId}/display";
            req.Method = "GET";

            using (var res = this.Parent.Web.Request(req))
            {
                var set = new TwitchBadgeSet();
                set.Read(res.ReadAsJson());

                return set;
            }

        }

    }

}
