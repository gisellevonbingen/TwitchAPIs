﻿using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitchAPIs.Web;

namespace TwitchAPIs
{
    public class TwitchAPIBadges : TwitchAPIPart
    {
        public TwitchAPIBadges(TwitchAPI parent) : base(parent)
        {

        }

        public TwitchBadgeSet GetGlobalBadges()
        {
            var req = new RequestParameter();
            req.URL = $"https://badges.twitch.tv/v1/badges/global/display";
            req.Method = "GET";

            using (var res = this.Parent.Web.Request(req))
            {
                var set = new TwitchBadgeSet();
                set.Read(res.ReadAsJSON());

                return set;
            }

        }

        public TwitchBadgeSet GetChannelBadges(string channelId)
        {
            var req = new RequestParameter();
            req.URL = $"https://badges.twitch.tv/v1/badges/channels/{channelId}/display";
            req.Method = "GET";

            using (var res = this.Parent.Web.Request(req))
            {
                var set = new TwitchBadgeSet();
                set.Read(res.ReadAsJSON());

                return set;
            }

        }

    }

}
