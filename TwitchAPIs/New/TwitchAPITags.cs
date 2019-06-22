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

            var tags = new TwitchAllStreamTags();
            tags.Tags = jToken.ReadArray("data", t => new TwitchStreamTag(t));
            tags.Pagination = jToken.ReadIfExist("pagination", t => new Pagination(t));

            return tags;
        }

    }

}
