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

        public string ClientId { get; set; }
        public string AccessToken { get; set; }

        public TwitchAPI()
        {
            this.Web = new WebExplorer();
            this.User = new TwitchAPIUser(this);
            this.Authorization = new TwitchAPIAuthorization(this);

            this.ClientId = null;
            this.AccessToken = null;
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

        public void SetupRequest(RequestParameter request)
        {
            var haders = request.Headers;
            haders["Client-Id"] = this.ClientId;

            var accessToken = this.AccessToken;

            if (accessToken != null)
            {
                var url = request.URL.ToLowerInvariant();

                if (url.StartsWith("https://api.twitch.tv/helix/") == true)
                {
                    haders["Authorization"] = $"Bearer {accessToken}";
                }
                else if (url.StartsWith("https://api.twitch.tv/kraken/") == true)
                {
                    haders["Authorization"] = $"OAuth {accessToken}";
                }

            }

        }

        public SessionResponse Request(RequestParameter request)
        {
            this.SetupRequest(request);
            return this.Web.Request(request);
        }

    }

}
