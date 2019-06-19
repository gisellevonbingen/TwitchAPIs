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

            var clips = new TwitchClips();
            clips.Clips = jToken.ReadArray("data", t => new TwitchClip(t)) ?? new TwitchClip[0];
            clips.Pagination = jToken.ReadIfExist("pagination", t => new Pagination(t));

            return clips;
        }

    }

}
