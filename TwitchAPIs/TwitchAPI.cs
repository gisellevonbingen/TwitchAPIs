using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Giselle.Commons.Web;
using Newtonsoft.Json.Linq;

namespace TwitchAPIs
{
    public class TwitchAPI
    {
        public WebExplorer Web { get; }
        public TwitchAPIUsers Users { get; }
        public TwitchAPIAuthorization Authorization { get; }
        public TwitchAPISearch Search { get; }
        public TwitchAPIChannels Channels { get; }
        public TwitchAPIGames Games { get; }
        public TwitchAPIBadges Badges { get; }
        public TwitchAPIChat Chat { get; }
        public TwitchAPIClips Clips { get; }

        public string ClientId { get; set; }
        public string AccessToken { get; set; }

        public TwitchAPI()
        {
            this.Web = new WebExplorer();
            this.Users = new TwitchAPIUsers(this);
            this.Authorization = new TwitchAPIAuthorization(this);
            this.Search = new TwitchAPISearch(this);
            this.Channels = new TwitchAPIChannels(this);
            this.Games = new TwitchAPIGames(this);
            this.Badges = new TwitchAPIBadges(this);
            this.Channels = new TwitchAPIChannels(this);
            this.Chat = new TwitchAPIChat(this);
            this.Clips = new TwitchAPIClips(this);

            this.ClientId = null;
            this.AccessToken = null;
        }

        public string GetRequestBaseURL(APIVersion version)
        {
            if (version == APIVersion.New)
            {
                return "https://api.twitch.tv/helix/";
            }
            else if (version == APIVersion.V5)
            {
                return "https://api.twitch.tv/kraken/";
            }

            return null;
        }

        public void SetupRequest(WebRequestParameter request, APIVersion? version)
        {
            var headers = request.Headers;
            headers["Client-Id"] = this.ClientId;

            var accessToken = this.AccessToken;

            if (accessToken != null)
            {
                if (version == APIVersion.New)
                {
                    headers["Authorization"] = $"Bearer {accessToken}";
                }
                else if (version == APIVersion.V5)
                {
                    headers["Authorization"] = $"OAuth {accessToken}";
                }

            }

            if (version == APIVersion.V5)
            {
                request.Accept = "application/vnd.twitchtv.v5+json";
            }

        }

        public void ThrowIfError(JToken jToken, string errorKey = null)
        {
            errorKey = errorKey ?? "error";

            var error = errorKey != null ? jToken.Value<string>(errorKey) : null;

            if (string.IsNullOrWhiteSpace(error) == false)
            {
                var messageKey = "message";
                string message = messageKey != null ? jToken.Value<string>(messageKey) : null;

                if (string.IsNullOrWhiteSpace(message) == false)
                {
                    throw new TwitchException($"{error} - {message}");
                }
                else
                {
                    throw new TwitchException($"{error}");
                }

            }

        }

        public JToken ReadAsJsonThrowIfError(WebResponse response, string errorKey = null)
        {
            var jToken = response.ReadAsJson();

            this.ThrowIfError(jToken, errorKey);

            return jToken;
        }

        public JToken RequestAsJson(TwitchAPIRequest apiRequest, string errorKey = null)
        {
            using (var response = this.Request(apiRequest))
            {
                return this.ReadAsJsonThrowIfError(response, errorKey);
            }

        }

        public WebResponse Request(TwitchAPIRequest apiRequest, string errorKey = null)
        {
            var webRequest = this.CreateWebRequest(apiRequest);
            return this.Web.Request(webRequest);
        }

        public WebRequestParameter CreateWebRequest(TwitchAPIRequest apiRequest)
        {
            var baseURI = this.GetBaseURI(apiRequest.BaseURL, apiRequest.Version, apiRequest.Path);
            var queryValues = new QueryValues();
            queryValues.AddRange(QueryValues.Parse(baseURI.Query));
            queryValues.AddRange(apiRequest.QueryValues);

            var request = new WebRequestParameter();
            request.URL = $"{baseURI.Scheme}{Uri.SchemeDelimiter}{baseURI.Host}{baseURI.LocalPath}{queryValues}";
            request.Method = apiRequest.Method;
            this.SetupRequest(request, apiRequest.Version);

            return request;
        }

        private Uri GetBaseURI(string baseURL, APIVersion? version, string path)
        {
            Uri baseURI = null;

            if (string.IsNullOrWhiteSpace(baseURL) == false)
            {
                baseURI = new Uri(baseURL);
            }
            else if (version.HasValue == true)
            {
                baseURI = new Uri($"{this.GetRequestBaseURL(version.Value)}{path}");
            }

            return baseURI ?? throw new TwitchException($"{nameof(baseURL)} or {nameof(version)}, {nameof(path)} is not specificated");
        }

    }

}
