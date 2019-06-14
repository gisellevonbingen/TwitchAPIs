using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace TwitchAPIs
{
    public class TwitchAPIUsers : TwitchAPIPart
    {
        public TwitchAPIUsers(TwitchAPI parent) : base(parent)
        {

        }

        public TwitchUser UpdateUser(string description)
        {
            var queryValues = new Dictionary<string, string>();
            queryValues["description"] = HttpUtility.UrlEncode(description);
            var jToken = this.Parent.Request(new TwitchAPIRequestParameter() { Method = "PUT", Version = APIVersion.New, Path = "users", QueryValues = queryValues });

            return this.ParseUsers(jToken).FirstOrDefault();
        }

        public TwitchUserFollows GetUserFollows(FollowsType type, string id)
        {
            return this.GetUserFollows(type, id, null);
        }

        public TwitchUserFollows GetUserFollows(FollowsType type, string id, string cursor)
        {
            var queryValues = new Dictionary<string, string>();
            queryValues[$"{type.Request}_id"] = id;
            queryValues[$"after"] = cursor;

            var jToken = this.Parent.Request(new TwitchAPIRequestParameter() { Method = "GET", Version = APIVersion.New, Path = "users/follows", QueryValues = queryValues });

            var uerFollows = new TwitchUserFollows();
            uerFollows.Total = jToken.Value<int>("total");
            uerFollows.Cursor = jToken["pagination"].Value<string>("cursor");
            uerFollows.Follows = jToken.ReadArray("data", t => new TwitchFollow().Read(t, type)) ?? new TwitchFollow[0];

            return uerFollows;
        }

        public TwitchUser GetUser(UserRequest request)
        {
            var users = this.GetUsers(new UserRequest[] { request });
            return users.FirstOrDefault();
        }

        public TwitchUser[] GetUsers(IEnumerable<UserRequest> requests)
        {
            var queryValues = requests.ToDictionary(r => r.Type.ToString().ToLowerInvariant(), r => r.Value);
            var jToken = this.Parent.Request(new TwitchAPIRequestParameter() { Method = "GET", Path = "users", QueryValues = queryValues, Version = APIVersion.New });

            return this.ParseUsers(jToken);
        }

        private TwitchUser[] ParseUsers(JToken token)
        {
            return token.ReadArray("data", t => new TwitchUser().Read(t)) ?? new TwitchUser[0];
        }

    }

}
