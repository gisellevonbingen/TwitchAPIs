using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Giselle.Commons;
using Giselle.Commons.Web;
using Newtonsoft.Json.Linq;
using TwitchAPIs.New;
using TwitchAPIs.Authentication;
using TwitchAPIs.Other;
using TwitchAPIs.V5;

namespace TwitchAPIs
{
    public class TwitchAPI
    {
        public WebExplorer Web { get; }
        public TwitchAPIAuthentication Authentication { get; }
        public TwitchAPIBadges Badges { get; }

        public TwitchAPINew New { get; }
        public TwitchAPIV5 V5 { get; }


        public string ClientId { get; set; }
        public string AccessToken { get; set; }

        public TwitchAPI()
        {
            this.Web = new WebExplorer();
            this.Authentication = new TwitchAPIAuthentication(this);
            this.Badges = new TwitchAPIBadges(this);

            this.New = new TwitchAPINew(this);
            this.V5 = new TwitchAPIV5(this);

            this.ClientId = null;
            this.AccessToken = null;
        }

        public string GetRequestBaseUrl(APIVersion version)
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

            if (version.HasValue == true)
            {
                headers["Client-Id"] = this.ClientId;
            }

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

        public WebResponse Request(TwitchAPIRequest apiRequest)
        {
            var webRequest = this.CreateWebRequest(apiRequest);
            return this.Web.Request(webRequest);
        }

        public WebRequestParameter CreateWebRequest(TwitchAPIRequest apiRequest)
        {
            var baseUri = this.GetBaseUri(apiRequest.BaseUrl, apiRequest.Version, apiRequest.Path);
            var queryValues = new QueryValues();
            queryValues.AddRange(QueryValues.Parse(baseUri.Query));
            queryValues.AddRange(apiRequest.QueryValues);

            var request = new WebRequestParameter();
            request.RetryCount = 0;
            request.Uri = $"{baseUri.Scheme}{Uri.SchemeDelimiter}{baseUri.Host}{baseUri.LocalPath}{queryValues.ToString(false)}";
            request.Method = apiRequest.Method;
            request.WriteParameter = apiRequest.PostData;
            this.SetupRequest(request, apiRequest.Version);

            return request;
        }

        private Uri GetBaseUri(string baseUrl, APIVersion? version, string path)
        {
            Uri baseUri = null;

            if (string.IsNullOrWhiteSpace(baseUrl) == false)
            {
                baseUri = new Uri(baseUrl);
            }
            else if (version.HasValue == true)
            {
                baseUri = new Uri($"{this.GetRequestBaseUrl(version.Value)}{path}");
            }

            return baseUri ?? throw new TwitchException($"{nameof(baseUrl)} or {nameof(version)}, {nameof(path)} is not specificated");
        }

    }

}
