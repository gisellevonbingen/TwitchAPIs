using Giselle.Commons;
using Giselle.Commons.Web;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.OAuth
{
    public class TwitchAPIAuthorization : TwitchAPIPart
    {
        public TwitchAPIAuthorization(TwitchAPI parent) : base(parent)
        {

        }

        public OAuthAuthorization GetOAuthAuthorization(Uri responseURI, OAuthRequest request)
        {
            var responseType = request.ResponseType;
            QueryValues queryValues = null;
            OAuthAuthorization authorization = null;

            if (request is OAuthRequestAuthorization auth)
            {
                queryValues = QueryValues.Parse(StringUtils.RemovePrefix(responseURI.Query, "?"));
                this.EnsureOAuthStateEquals(queryValues, request);

                var accessTokenRequest = new OAuthAccessTokenRequest();
                accessTokenRequest.ClientSecret = auth.ClientSecret;
                accessTokenRequest.Code = queryValues.Single("code");
                accessTokenRequest.RedirectURI = auth.RedirectURI;
                authorization = this.GetOAuthAuthorization(accessTokenRequest);
            }
            else if (request is OAuthRequestToken)
            {
                queryValues = QueryValues.Parse(StringUtils.RemovePrefix(responseURI.Fragment, "#"));
                this.EnsureOAuthStateEquals(queryValues, request);

                authorization = new OAuthAuthorization(queryValues);
            }
            else
            {
                throw new ArgumentException("Invalid OAuthRequest Type", nameof(request));
            }

            return authorization;
        }

        public OAuthAuthorization RefreshOAuthAuthorization(string refreshToken, string clientSecret)
        {
            var apiRequest = new TwitchAPIRequest();
            apiRequest.BaseURL = "https://id.twitch.tv/oauth2/token";
            apiRequest.Method = "POST";
            apiRequest.QueryValues.Add("grant_type", "refresh_token");
            apiRequest.QueryValues.Add("refresh_token", refreshToken);
            apiRequest.QueryValues.Add("client_id", this.Parent.ClientId);
            apiRequest.QueryValues.Add("client_secret", clientSecret);
            var jToken = this.Parent.RequestAsJson(apiRequest, "status");

            return new OAuthAuthorization(jToken);
        }

        public void EnsureOAuthStateEquals(QueryValues queryValues, OAuthRequest request)
        {
            var requested = request.State;

            if (requested == null)
            {
                return;
            }

            var responsed = queryValues.Single("state");

            if (requested.Equals(responsed) == false)
            {
                throw new TwitchException($"OAuth state mismatched - Request:{requested} vs Response:{responsed})");
            }

        }

        public OAuthAuthorization GetOAuthAuthorization(OAuthAccessTokenRequest request)
        {
            var apiRequest = new TwitchAPIRequest();
            apiRequest.BaseURL = "https://id.twitch.tv/oauth2/token";
            apiRequest.Method = "POST";
            apiRequest.QueryValues.Add("client_id", this.Parent.ClientId);
            apiRequest.QueryValues.Add("client_secret", request.ClientSecret);
            apiRequest.QueryValues.Add("code", request.Code);
            apiRequest.QueryValues.Add("grant_type", "authorization_code");
            apiRequest.QueryValues.Add("redirect_uri", request.RedirectURI);
            var jToken = this.Parent.RequestAsJson(apiRequest, "status");

            return new OAuthAuthorization(jToken);
        }

        public string GetOAuthURI(OAuthRequest request)
        {
            var apiRequest = new TwitchAPIRequest();
            apiRequest.BaseURL = "https://id.twitch.tv/oauth2/authorize";
            apiRequest.Method = "GET";
            apiRequest.QueryValues.Add("client_id", this.Parent.ClientId);
            apiRequest.QueryValues.Add("response_type", request.ResponseType);
            apiRequest.QueryValues.Add("redirect_uri", request.RedirectURI);
            apiRequest.QueryValues.Add("scope", request.Scope);

            var forceVerify = request.ForceVerify;
            var state = request.State;

            if (forceVerify == true)
            {
                apiRequest.QueryValues.Add("force_verify", forceVerify.ToString().ToLowerInvariant());
            }

            if (string.IsNullOrWhiteSpace(state) == false)
            {
                apiRequest.QueryValues.Add("state", state);
            }

            using (var response = this.Parent.Request(apiRequest))
            {
                return response.Impl.ResponseUri.AbsoluteUri;
            }

        }

    }

}
