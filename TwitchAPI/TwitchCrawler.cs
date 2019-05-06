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

        public TwitchFollowers GetUserFollows(string id)
        {
            return this.GetUserFollows(id, null);
        }

        public TwitchFollowers GetUserFollows(string id, string cursor)
        {
            var req = this.CreateDefaultRequestParameter();
            req.URL = "https://api.twitch.tv/helix/users/follows?to_id=" + id;

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
                follower.Id = token.Value<string>("from_id");
                follower.DisplayName = token.Value<string>("from_name");
                follower.FollowedAt = token.Value<DateTime>("followed_at");

                followers.Followers.Add(follower);
            }

            return followers;
        }

        public TwitchUser GetUser(string loginName)
        {
            var req = this.CreateDefaultRequestParameter();
            req.URL = "https://api.twitch.tv/helix/users?login=" + loginName;
            req.Method = "GET";

            var jobj = this.GetJsonResponse(req);
            var data = (JArray)jobj["data"];
            var count = data.Count;

            if (count == 1)
            {
                var token = data[0];
                var user = new TwitchUser();
                user.Id = token.Value<string>("id");
                user.Login = token.Value<string>("login");
                user.DisplayName = token.Value<string>("display_name");

                return user;
            }
            else
            {
                return null;
            }

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
