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
            var path = $"users?description={HttpUtility.UrlEncode(description)}";
            var jToken = this.Parent.Request(APIVersion.New, path, "PUT");

            return this.ParseUsers(jToken).FirstOrDefault();
        }

        public TwitchUserFollows GetUserFollows(FollowsType type, string id)
        {
            return this.GetUserFollows(type, id, null);
        }

        public TwitchUserFollows GetUserFollows(FollowsType type, string id, string cursor)
        {
            var path = $"users/follows?{type.Request}_id={id}";

            if (cursor != null)
            {
                path += "&after=" + cursor;
            }

            var jToken = this.Parent.Request(APIVersion.New, path, "GET");

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
            var path = $"users?{string.Join("&", requests)}";
            var jToken = this.Parent.Request(APIVersion.New, path, "GET");

            return this.ParseUsers(jToken);
        }

        private TwitchUser[] ParseUsers(JToken token)
        {
            return token.ReadArray("data", t => new TwitchUser().Read(t)) ?? new TwitchUser[0];
        }

    }

}
