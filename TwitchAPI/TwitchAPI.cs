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
    public class TwitchAPI
    {
        public WebExplorer Web { get; }
        public TwitchAPIUser User { get; }
        public TwitchAPIAuthorization Authorization { get; }
        public TwitchAPISearch Search { get; }
        public TwitchAPIChannel Channel { get; }

        public string ClientId { get; set; }
        public string AccessToken { get; set; }

        public TwitchAPI()
        {
            this.Web = new WebExplorer();
            this.User = new TwitchAPIUser(this);
            this.Authorization = new TwitchAPIAuthorization(this);
            this.Search = new TwitchAPISearch(this);
            this.Channel = new TwitchAPIChannel(this);

            this.ClientId = null;
            this.AccessToken = null;
        }

        public JToken EnsureNotError(JToken token, string checkKey, string messageKey)
        {
            var error = token.Value<string>(checkKey);

            if (error != null)
            {
                var message = token.Value<string>(messageKey);
                throw new TwitchException(error + " - " + message);
            }

            return token;
        }

        public JToken EnsureNotError(JToken token)
        {
            return this.EnsureNotError(token, "error", "message");
        }

        public void SetupRequest(RequestParameter request, APIVersion version)
        {
            var headers = request.Headers;
            headers["Client-Id"] = this.ClientId;

            var accessToken = this.AccessToken;

            if (accessToken != null)
            {
                var url = request.URL.ToLowerInvariant();

                if (url.StartsWith("https://api.twitch.tv/helix/") == true)
                {
                    headers["Authorization"] = $"Bearer {accessToken}";
                }
                else if (url.StartsWith("https://api.twitch.tv/kraken/") == true)
                {
                    headers["Authorization"] = $"OAuth {accessToken}";
                }

            }

            if (version == APIVersion.V5)
            {
                request.Accept = "application/vnd.twitchtv.v5+json";
            }

        }

        public SessionResponse Request(APIVersion version, string url, string method)
        {
            var request = this.CreateRequest(version, url, method);
            return this.Web.Request(request);
        }

        public RequestParameter CreateRequest(APIVersion version, string url, string method)
        {
            var request = new RequestParameter();
            request.URL = url;
            request.Method = method;
            this.SetupRequest(request, version);

            return request;
        }

    }

}
