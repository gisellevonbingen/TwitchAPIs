using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json.Linq;
using TwitchAPI.Web;

namespace TwitchAPI
{
    public class TwitchCrawler
    {
        public WebExplorer Web { get; }
        public string ClientId { get; }
        public string SecretKey { get; }

        public TwitchCrawler(string clientId, string secretKey)
        {
            this.Web = new WebExplorer();
            this.ClientId = clientId;
            this.SecretKey = secretKey;
        }

        public TwitchUser UpdateUser(string bearerAccessToken, string description)
        {
            var req = this.CreateDefaultRequestParameter();
            req.Method = "PUT";
            req.URL = $"https://api.twitch.tv/helix/users?description={description}";
            req.Headers["Authorization"] = $"Bearer {bearerAccessToken}";

            var jobj = this.GetResponseAsJson(req);
            return this.ParseUser(jobj);
        }

        public Authorization ParseAuthorization(JToken jToken)
        {
            var authorization = new Authorization();
            authorization.AccessToken = jToken.Value<string>("access_token");
            authorization.RefreshToken = jToken.Value<string>("refresh_token");
            authorization.ExpiresIn = jToken.Value<int>("expires_in");
            authorization.Scope = jToken.GetArrayValues<string>("scope")?.ToArray();
            authorization.TokenType = jToken.Value<string>("token_type");

            return authorization;
        }

        public Authorization RefreshAuthorize(string accessToken)
        {
            var req = this.CreateDefaultRequestParameter();
            req.Method = "POST";
            req.URL = $"https://id.twitch.tv/oauth2/token?grant_type=refresh_token&refresh_token={accessToken}&client_id=${this.ClientId}&client_secret={this.SecretKey}";

            var jobj = this.GetResponseAsJson(req);
            return this.ParseAuthorization(jobj);
        }

        public Authorization Authorize(string scope)
        {
            var req = this.CreateDefaultRequestParameter();
            req.Method = "POST";
            req.URL = $"https://id.twitch.tv/oauth2/token?client_id={this.ClientId}&client_secret={this.SecretKey}&grant_type=client_credentials&scope={scope}";

            var jobj = this.GetResponseAsJson(req);
            return this.ParseAuthorization(jobj);
        }

        public TwitchFollowers GetUserFollows(FollowsType type, string id)
        {
            return this.GetUserFollows(type, id, null);
        }

        public TwitchFollowers GetUserFollows(FollowsType type, string id, string cursor)
        {
            var req = this.CreateDefaultRequestParameter();
            req.URL = $"https://api.twitch.tv/helix/users/follows?{type.Request}_id={id}";

            if (cursor != null)
            {
                req.URL += "&after=" + cursor;
            }

            var jobj = this.GetResponseAsJson(req);
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
            req.URL = $"https://api.twitch.tv/helix/users?{string.Join("&", requests)}";

            var jobj = this.GetResponseAsJson(req);
            var data = (JArray)jobj["data"];
            var count = data.Count;
            var users = new List<TwitchUser>();

            for (int i = 0; i < count; i++)
            {
                var token = data[i];
                var user = this.ParseUser(token);
                users.Add(user);
            }

            return users;
        }

        private TwitchUser ParseUser(JToken token)
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

        public string GetResponseAsString(RequestParameter request)
        {
            using (var response = this.Web.Request(request))
            {
                using (var stream = response.GetResponseStream())
                {
                    using (var reader = new StreamReader(stream))
                    {
                        var content = reader.ReadToEnd();
                        return content;
                    }

                }

            }

        }

        public JObject GetResponseAsJson(RequestParameter request)
        {
            var content = this.GetResponseAsString(request);
            var jobj = JObject.Parse(content);

            var error = jobj.Value<string>("error");

            if (error != null)
            {
                var message = jobj.Value<string>("message");
                throw new TwitchException(message);
            }

            return jobj;
        }

        public RequestParameter CreateDefaultRequestParameter()
        {
            var rp = new RequestParameter();
            rp.Method = "GET";
            rp.Headers["Client-Id"] = this.ClientId;

            return rp;
        }

    }

}
