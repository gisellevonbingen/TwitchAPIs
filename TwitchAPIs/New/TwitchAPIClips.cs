using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.New
{
    public class TwitchAPIClips : TwitchAPIPart
    {
        public TwitchAPIClips(TwitchAPI parent) : base(parent)
        {

        }

        public TwitchClipEdit CreateClip(string broadcasterId, bool? hasDelay = null)
        {
            var apiRequest = new TwitchAPIRequest();
            apiRequest.Version = APIVersion.New;
            apiRequest.Path = "clips";
            apiRequest.Method = "POST";
            apiRequest.QueryValues.Add("broadcaster_id", broadcasterId);
            apiRequest.QueryValues.Add("has_delay", hasDelay);
            var jToken = this.Parent.RequestAsJson(apiRequest);

            return jToken.ReadArray("data", t => new TwitchClipEdit(t)).FirstOrDefault();
        }

        public TwitchClips GetClips(TwitchGetClipsOptions options)
        {
            var apiRequest = new TwitchAPIRequest();
            apiRequest.Version = APIVersion.New;
            apiRequest.Path = "clips";
            apiRequest.Method = "GET";
            apiRequest.QueryValues.Add("broadcaster_id", options.BroadcasterId);
            apiRequest.QueryValues.Add("game_id", options.GameId);
            apiRequest.QueryValues.AddRange("id", options.Ids);
            apiRequest.QueryValues.Add("after", options.After);
            apiRequest.QueryValues.Add("before", options.Before);
            apiRequest.QueryValues.Add("ended_at", TwitchDateTimeUtils.ToString(options.EndedAt));
            apiRequest.QueryValues.Add("first", options.First);
            apiRequest.QueryValues.Add("started_at", TwitchDateTimeUtils.ToString(options.StartedAt));
            var jToken = this.Parent.RequestAsJson(apiRequest);

            return new TwitchClips(jToken);
        }

    }

}
