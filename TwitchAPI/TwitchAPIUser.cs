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
            var req = new RequestParameter();
            req.Method = "PUT";
            req.URL = $"https://api.twitch.tv/helix/users?description={HttpUtility.UrlEncode(description)}";

            using (var res = this.Parent.Request(req))
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
            var req = new RequestParameter();
            req.Method = "GET";
            req.URL = $"https://api.twitch.tv/helix/users/follows?{type.Request}_id={id}";

            if (cursor != null)
            {
                req.URL += "&after=" + cursor;
            }

            using (var res = this.Parent.Request(req))
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
                    follower.Id = token.Value<string>(type.Response + "_id");
                    follower.DisplayName = token.Value<string>(type.Response + "_name");
                    follower.FollowedAt = token.Value<DateTime>("followed_at");

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
            var req = new RequestParameter();
            req.Method = "GET";
            req.URL = $"https://api.twitch.tv/helix/users?{string.Join("&", requests)}";

            using (var res = this.Parent.Request(req))
            {
                return this.ParseUsers(res.ReadAsJSON());
            }

        }

        private List<TwitchUser> ParseUsers(JToken token)
        {
            this.Parent.EnsureNotError(token);

            var data = (JArray)token["data"];
            var count = data.Count;
            var users = new List<TwitchUser>();

            for (int i = 0; i < count; i++)
            {
                var itemToken = data[i];
                var user = this.ParseUser(itemToken);
                users.Add(user);
            }

            return users;
        }

        public TwitchUser ParseUser(JToken token)
        {
            var user = new TwitchUser();
            user.BroadcasterType = token.Value<string>("broadcaster_type");
            user.Description = token.Value<string>("description");
            user.DisplayName = token.Value<string>("display_name");
            user.Email = token.Value<string>("email");
            user.Id = token.Value<string>("id");
            user.Login = token.Value<string>("login");
            user.OfflineImageUrl = token.Value<string>("offline_image_url");
            user.ProfileImageUrl = token.Value<string>("profile_image_url");
            user.Type = token.Value<string>("type");
            user.ViewCount = token.Value<int>("view_count");

            return user;
        }

    }

}
