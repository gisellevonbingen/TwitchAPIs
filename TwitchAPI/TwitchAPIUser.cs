using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using TwitchAPI.Web;

namespace TwitchAPI
{
    public class TwitchAPIUser : TwitchAPIPart
    {
        public TwitchAPIUser(TwitchAPI parent) : base(parent)
        {

        }

        public TwitchUser UpdateUser(string description)
        {
            var url = $"https://api.twitch.tv/helix/users?description={HttpUtility.UrlEncode(description)}";

            using (var res = this.Parent.Request(APIVersion.New, url, "PUT"))
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
            var url = $"https://api.twitch.tv/helix/users/follows?{type.Request}_id={id}";

            if (cursor != null)
            {
                url += "&after=" + cursor;
            }

            using (var res = this.Parent.Request(APIVersion.New, url, "GET"))
            {
                var jobj = this.Parent.EnsureNotError(res.ReadAsJSON());
                var data = jobj.Value<JArray>("data");

                var followers = new TwitchUserFollows();
                followers.Total = jobj.Value<int>("total");
                followers.Cursor = jobj["pagination"].Value<string>("cursor");

                for (int i = 0; i < data.Count; i++)
                {
                    var token = data[i];
                    var follower = new TwitchFollow();
                    follower.Read(token, type);

                    followers.Follows.Add(follower);
                }

                return followers;
            }

        }

        public TwitchUser GetUser(UserRequest request)
        {
            var users = this.GetUsers(new UserRequest[] { request });
            return users.FirstOrDefault();
        }

        public List<TwitchUser> GetUsers(IEnumerable<UserRequest> requests)
        {
            var url = $"https://api.twitch.tv/helix/users?{string.Join("&", requests)}";

            using (var res = this.Parent.Request(APIVersion.New, url, "GET"))
            {
                return this.ParseUsers(res.ReadAsJSON());
            }

        }

        public List<TwitchUser> ParseUsers(JToken token)
        {
            this.Parent.EnsureNotError(token);

            var data = (JArray)token["data"];
            var count = data.Count;
            var users = new List<TwitchUser>();

            for (int i = 0; i < count; i++)
            {
                var itemToken = data[i];
                var user = new TwitchUser();
                user.Read(itemToken);
                users.Add(user);
            }

            return users;
        }

    }

}
