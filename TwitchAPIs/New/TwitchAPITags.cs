using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.New
{
    public class TwitchAPITags : TwitchAPIPart
    {
        public TwitchAPITags(TwitchAPI parent) : base(parent)
        {

        }

        public TwitchAllStreamTags GetAllStreamTags(string after = null, int? first = null, List<string> tagIds = null)
        {
            var apiRequest = new TwitchAPIRequest();
            apiRequest.Version = APIVersion.New;
            apiRequest.Path = "tags/streams";
            apiRequest.Method = "GET";
            apiRequest.QueryValues.Add("after", after);
            apiRequest.QueryValues.Add("first", first);
            apiRequest.QueryValues.AddRange("tag_id", tagIds);
            var jToken = this.Parent.RequestAsJson(apiRequest);

            return new TwitchAllStreamTags(jToken);
        }

        public TwitchStreamTag[] GetStreamTags(string broadcasterId)
        {
            var apiRequest = new TwitchAPIRequest();
            apiRequest.Version = APIVersion.New;
            apiRequest.Path = "streams/tags";
            apiRequest.Method = "GET";
            apiRequest.QueryValues.Add("broadcaster_id", broadcasterId);
            var jToken = this.Parent.RequestAsJson(apiRequest);

            return jToken.ReadArray("data", t => new TwitchStreamTag(t));
        }

        public void ReplaceStreamTags(string broadcasterId, IEnumerable<string> tagIds)
        {
            var postData = new JObject();
            postData["tags_id"] = new JArray(tagIds);

            var apiRequest = new TwitchAPIRequest();
            apiRequest.Version = APIVersion.New;
            apiRequest.Path = "streams/tags";
            apiRequest.Method = "PUT";
            apiRequest.ContentType = "application/json";
            apiRequest.QueryValues.Add("broadcaster_id", broadcasterId);
            apiRequest.PostData = postData.ToString(Formatting.None);

            using (var response = this.Parent.Request(apiRequest))
            {

            }

        }

    }

}
