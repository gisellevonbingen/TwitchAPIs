using System;
using System.Collections.Generic;
using System.Collections.Specialized;
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
        public TwitchCrawler(string clientId)
        {
            this.Web = new WebExplorer();
            this.ClientId = clientId;
        }

        public OAuthAuthorization ParseOAuthAuthorization(NameValueCollection map)
        {
            var authorization = new OAuthAuthorization();
            authorization.AccessToken = map["access_token"];
            authorization.RefreshToken = map["refresh_token"];
            authorization.ExpiresIn = NumberUtils.ToInt(map["expires_in"]);
            authorization.Scope = new string[] { map["scope"] };
            authorization.TokenType = map["token_type"];

            return authorization;
        }

        public OAuthAuthorization ParseOAuthAuthorization(JToken jToken)
        {
            var authorization = new OAuthAuthorization();
            authorization.AccessToken = jToken.Value<string>("access_token");
            authorization.RefreshToken = jToken.Value<string>("refresh_token");
            authorization.ExpiresIn = jToken.Value<int>("expires_in");
            authorization.Scope = jToken.GetArrayValues<string>("scope")?.ToArray();
            authorization.TokenType = jToken.Value<string>("token_type");

            return authorization;
        }

        public OAuthAuthorization GetOAuthAccessToken(OAuthAccessTokenRequest request)
        {
            var url = $"https://id.twitch.tv/oauth2/token";
            url += $"?client_id={this.ClientId}";
            url += $"&client_secret={request.ClientSecret}";
            url += $"&code={request.Code}";
            url += $"&grant_type=authorization_code";
            url += $"&redirect_uri={request.RedirectURI}";

            var req = this.CreateDefaultRequestParameter();
            req.Method = "POST";
            req.URL = url;

            using (var res = this.Web.Request(req))
            {
                var jobj = this.EnsureNotError(res.ReadAsJSON(), "status", "message");
                return this.ParseOAuthAuthorization(jobj);
            }

        }

        public string GetOAuthURI(OAuthRequest request)
        {
            var url = "https://id.twitch.tv/oauth2/authorize";
            url += $"?client_id={this.ClientId}";
            url += $"&response_type={request.ResponseType}";
            url += $"&redirect_uri={request.RedirectURI}";
            url += $"&scope={request.Scope}";

            var forceVerify = request.ForceVerify;
            var state = request.State;

            if (forceVerify == true)
            {
                url += $"&force_verify={forceVerify}";
            }

            if (string.IsNullOrWhiteSpace(state) == false)
            {
                url += $"&state={state}";
            }

            var req = this.CreateDefaultRequestParameter();
            req.Method = "GET";
            req.URL = url;

            using (var res = this.Web.Request(req))
            {
                return res.Impl.ResponseUri.AbsoluteUri;
            }

        }

        public TwitchFollowers GetUserFollows(FollowsType type, string id)
        {
            return this.GetUserFollows(type, id, null);
        }

        public TwitchFollowers GetUserFollows(FollowsType type, string id, string cursor)
        {
            var req = this.CreateDefaultRequestParameter();
            req.Method = "GET";
            req.URL = $"https://api.twitch.tv/helix/users/follows?{type.Request}_id={id}";

            if (cursor != null)
            {
                req.URL += "&after=" + cursor;
            }

            using (var res = this.Web.Request(req))
            {
                var jobj = this.EnsureNotError(res.ReadAsJSON());
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

        }

        public TwitchUser GetUser(UserRequest request)
        {
            var users = this.GetUsers(new UserRequest[] { request });
            return users.FirstOrDefault();
        }

        public List<TwitchUser> GetUsers(IEnumerable<UserRequest> requests)
        {
            var req = this.CreateDefaultRequestParameter();
            req.Method = "GET";
            req.URL = $"https://api.twitch.tv/helix/users?{string.Join("&", requests)}";

            using (var res = this.Web.Request(req))
            {
                var jobj = this.EnsureNotError(res.ReadAsJSON());
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

        public JToken EnsureNotError(JToken token, string checkKey, string messageKey)
        {
            var error = token.Value<string>(checkKey);

            if (error != null)
            {
                var message = token.Value<string>(messageKey);
                throw new TwitchException(message);
            }

            return token;
        }

        public JToken EnsureNotError(JToken token)
        {
            return this.EnsureNotError(token, "error", "message");
        }

        public RequestParameter CreateDefaultRequestParameter()
        {
            var rp = new RequestParameter();
            rp.Headers["Client-Id"] = this.ClientId;

            return rp;
        }

    }

}
