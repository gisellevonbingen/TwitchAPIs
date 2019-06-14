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

            using (var res = this.Parent.Request(APIVersion.New, path, "PUT"))
            {
                return this.ParseUsers(res.ReadAsJSON()).FirstOrDefault();
            }

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

            using (var res = this.Parent.Request(APIVersion.New, path, "GET"))
            {
                var jobj = this.Parent.EnsureNotError(res.ReadAsJSON());
                var data = jobj.Value<JArray>("data");

                var uerFollows = new TwitchUserFollows();
                uerFollows.Total = jobj.Value<int>("total");
                uerFollows.Cursor = jobj["pagination"].Value<string>("cursor");

                var follows = uerFollows.Follows = new TwitchFollow[data.Count];

                for (int i = 0; i < data.Count; i++)
                {
                    var token = data[i];
                    var follow = follows[i] = new TwitchFollow();
                    follow.Read(token, type);
                }

                return uerFollows;
            }

        }

        public TwitchUser GetUser(UserRequest request)
        {
            var users = this.GetUsers(new UserRequest[] { request });
            return users.FirstOrDefault();
        }

        public TwitchUser[] GetUsers(IEnumerable<UserRequest> requests)
        {
            var path = $"users?{string.Join("&", requests)}";

            using (var res = this.Parent.Request(APIVersion.New, path, "GET"))
            {
                return this.ParseUsers(res.ReadAsJSON());
            }

        }

        public TwitchUser[] ParseUsers(JToken token)
        {
            this.Parent.EnsureNotError(token);

            var data = token["data"] as JArray;

            if (data == null)
            {
                return new TwitchUser[0];
            }

            var count = data.Count;
            var users = new TwitchUser[count];

            for (int i = 0; i < count; i++)
            {
                var itemToken = data[i];
                var user = users[i] = new TwitchUser();
                user.Read(itemToken);
            }

            return users;
        }

    }

}
