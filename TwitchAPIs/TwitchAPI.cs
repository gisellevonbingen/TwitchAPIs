﻿using System;
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

        public void SetupRequest(WebRequestParameter request, APIVersion version)
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

        public void ThrowIfError(APIVersion? version, JToken jToken, string errorKey = null, string messageKey = null)
        {
            if (version == APIVersion.V5)
            {
                errorKey = errorKey ?? "error";
                messageKey = messageKey ?? "message";
            }

            var error = errorKey != null ? jToken.Value<string>(errorKey) : null;

            if (error != null)
            {
                string message = messageKey != null ? jToken.Value<string>(messageKey) : null;

                if (message != null)
                {
                    throw new TwitchException($"{error} - {message}");
                }
                else
                {
                    throw new TwitchException($"{error}");
                }

            }

        }

        public JToken ReadAsJSON(APIVersion? version, WebResponse response, string errorKey = null, string messageKey = null)
        {
            var jToken = response.ReadAsJSON();

            this.ThrowIfError(version, jToken, errorKey, messageKey);

            return jToken;
        }

        public JToken Request(string url, string method, string errorKey = null, string messageKey = null)
        {
            var request = this.CreateRequest(url, method);
            return this.ReadAsJSON(null, this.Web.Request(request), errorKey, messageKey);
        }

        public JToken Request(APIVersion version, string path, string method, string errorKey = null, string messageKey = null)
        {
            var request = this.CreateRequest(version, path, method);
            return this.ReadAsJSON(version, this.Web.Request(request), errorKey, messageKey);
        }

        public WebRequestParameter CreateRequest(string url, string method)
        {
            var request = new WebRequestParameter();
            request.URL = url;
            request.Method = method;

            return request;
        }

        public WebRequestParameter CreateRequest(APIVersion version, string path, string method)
        {
            var url = this.GetRequestBaseURL(version) + path;
            var request = this.CreateRequest(url, method);

            this.SetupRequest(request, version);

            return request;
        }

    }

}
