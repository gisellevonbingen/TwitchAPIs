using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using TwitchAPI.Web;

namespace TwitchAPI
{
    public class TwitchCrawler
    {
        public WebExplorer Web { get; }
        public string ClientId { get; }

        public TwitchCrawler(string clientId)
        {
            this.Web = new WebExplorer();
            this.ClientId = clientId;
        }

        public TwitchFollowers GetUserFollows(FollowsType type, string id)
        {
            return this.GetUserFollows(type, id, null);
        }

        public TwitchFollowers GetUserFollows(FollowsType type, string id, string cursor)
        {
            var req = this.CreateDefaultRequestParameter();
            req.URL = "https://api.twitch.tv/helix/users/follows?" + type.Request + "_id=" + id;

            if (cursor != null)
            {
                req.URL += "&after=" + cursor;
            }

            req.Method = "GET";

            var jobj = this.GetJsonResponse(req);
            var data = jobj.Value<JArray>("data");

            var followers = new TwitchFollowers();
            followers.Total = jobj.Value<int>("total");
            followers.Cursor = jobj["pagination"].Value<string>("cursor");

            for (int i = 0; i < data.Count; i++)
            {
                var token = data[i];
                var follower = new TwitchFollower();
                follower.Id = token.Value<string>(type.Response + "_id");
                follower.DisplayName = token.Value<string>(type.Response + "_name");
                follower.FollowedAt = token.Value<DateTime>("followed_at");

                followers.Followers.Add(follower);
            }

            return followers;
        }

        public TwitchUser GetUser(UserRequest request)
        {
            var users = this.GetUsers(new UserRequest[] { request });
            return users.FirstOrDefault();
        }

        public List<TwitchUser> GetUsers(IEnumerable<UserRequest> requests)
        {
            var req = this.CreateDefaultRequestParameter();
            req.URL = "https://api.twitch.tv/helix/users?" + string.Join("&", requests);
            req.Method = "GET";

            var jobj = this.GetJsonResponse(req);
            var data = (JArray)jobj["data"];
            var count = data.Count;
            var users = new List<TwitchUser>();

            for (int i = 0; i < count; i++)
            {
                var token = data[i];
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
                users.Add(user);
            }

            return users;
        }

        public JObject GetJsonResponse(RequestParameter request)
        {
            using (var response = this.Web.Request(request))
            {
                var content = response.ReadToEnd();
                var jobj = JObject.Parse(content);

                var error = jobj.Value<string>("error");

                if (error != null)
                {
                    var message = jobj.Value<string>("message");
                    throw new TwitchException(message);
                }

                return jobj;
            }

        }

        public RequestParameter CreateDefaultRequestParameter()
        {
            var rp = new RequestParameter();
            rp.Headers["Client-Id"] = this.ClientId;

            return rp;
        }

    }

}
