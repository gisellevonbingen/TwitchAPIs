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

            return this.ParseUsers(jToken).FirstOrDefault();
        }

        public TwitchUserFollows GetUserFollows(string fromId = null, string toId = null, string after = null)
        {
            var apiRequest = new TwitchAPIRequest();
            apiRequest.Version = APIVersion.New;
            apiRequest.Path = "users/follows";
            apiRequest.Method = "GET";
            apiRequest.QueryValues.Add("from_id", fromId);
            apiRequest.QueryValues.Add("to_id", toId);
            apiRequest.QueryValues.Add("after", after);
            var jToken = this.Parent.RequestAsJson(apiRequest);

            var uerFollows = new TwitchUserFollows();
            uerFollows.Total = jToken.Value<int>("total");
            uerFollows.Pagination = jToken.ReadIfExist("pagination", t => new Pagination(t));
            uerFollows.Follows = jToken.ReadArray("data", t => new TwitchFollow(t));

            return uerFollows;
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
            apiRequest.QueryValues.AddRange(requests.Select(r => new QueryValue(r.Type.ToString().ToLowerInvariant(), r.Value)));
            var jToken = this.Parent.RequestAsJson(apiRequest);

            return this.ParseUsers(jToken);
        }

        private TwitchUser[] ParseUsers(JToken jToken)
        {
            return jToken.ReadArray("data", t => new TwitchUser(t));
        }

    }

}
