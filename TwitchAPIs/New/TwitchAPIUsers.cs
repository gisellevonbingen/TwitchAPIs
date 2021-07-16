using Giselle.Commons.Net.Http;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace TwitchAPIs.New
{
    public class TwitchAPIUsers : TwitchAPIPart
    {
        public TwitchAPIUsers(TwitchAPI parent) : base(parent)
        {

        }

        public TwitchUser UpdateUser(string description)
        {
            var apiRequest = new TwitchAPIRequest();
            apiRequest.Version = APIVersion.New;
            apiRequest.Path = "users";
            apiRequest.Method = "PUT";
            apiRequest.QueryValues.Add("description", HttpUtility.UrlEncode(description));
            var jToken = this.Parent.RequestAsJson(apiRequest);

            return jToken.ReadArray("data", t => new TwitchUser(t)).FirstOrDefault();
        }

        public TwitchAPIRequest GetUserFollowsRequest(string after = null, int? first = null, string fromId = null, string toId = null)
        {
            var apiRequest = new TwitchAPIRequest();
            apiRequest.Version = APIVersion.New;
            apiRequest.Path = "users/follows";
            apiRequest.Method = "GET";
            apiRequest.QueryValues.Add("after", after);
            apiRequest.QueryValues.Add("first", first);
            apiRequest.QueryValues.Add("from_id", fromId);
            apiRequest.QueryValues.Add("to_id", toId);

            return apiRequest;
        }

        public TwitchUserFollows GetUserFollows(string after = null, int? first = null, string fromId = null, string toId = null)
        {
            var apiRequest = this.GetUserFollowsRequest(after, first, fromId, toId);
            var jToken = this.Parent.RequestAsJson(apiRequest);

            return new TwitchUserFollows(jToken);
        }

        public TwitchUser GetUser()
        {
            var users = this.GetUsers(new UserRequest[0]);
            return users.FirstOrDefault();
        }

        public TwitchUser GetUser(UserRequest request)
        {
            var users = this.GetUsers(new UserRequest[] { request });
            return users.FirstOrDefault();
        }

        public TwitchUser[] GetUsers(IEnumerable<UserRequest> requests)
        {
            var apiRequest = new TwitchAPIRequest();
            apiRequest.Version = APIVersion.New;
            apiRequest.Path = "users";
            apiRequest.Method = "GET";
            apiRequest.QueryValues.AddRange(requests.Select(r => new QueryValue(r.Type.Name, r.Value)));
            var jToken = this.Parent.RequestAsJson(apiRequest);

            return jToken.ReadArray("data", t => new TwitchUser(t));
        }

    }

}
