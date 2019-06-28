using Giselle.Commons.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.Other.TwitchEmotesAPIs
{
    public class TwitchEmotesAPI : TwitchAPIPart
    {
        public TwitchEmotesAPI(TwitchAPI parent) : base(parent)
        {

        }

        public Emote[] GetEmotes(IEnumerable<string> emoteIds)
        {
            var req = new WebRequestParameter();
            req.Uri = $"https://api.twitchemotes.com/api/v4/emotes?id={string.Join(",", emoteIds)}";
            req.Method = "GET";

            using (var res = this.Parent.Web.Request(req))
            {
                var jToken = res.ReadAsJson();
                return jToken.ReadArray(t => new Emote(t));
            }

        }

        public EmoteSet[] GetEmoteSets(IEnumerable<string> setIds)
        {
            var req = new WebRequestParameter();
            req.Uri = $"https://api.twitchemotes.com/api/v4/sets?id={string.Join(",", setIds)}";
            req.Method = "GET";

            using (var res = this.Parent.Web.Request(req))
            {
                var jToken = res.ReadAsJson();
                return jToken.ReadArray(t => new EmoteSet(t));
            }

        }

    }

}
