using Giselle.Commons;
using Giselle.Commons.Web;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.Authentication
{
    public class TwitchAPIAuthentication : TwitchAPIPart
    {
        public TwitchAPIAuthentication(TwitchAPI parent) : base(parent)
        {

        }

        public string GetCodeAuthorizeUri(OAuthRequestCode request)
        {
            var apiRequest = new TwitchAPIRequest();
            apiRequest.BaseURL = "https://id.twitch.tv/oauth2/authorize";
            apiRequest.Method = "GET";
            apiRequest.QueryValues.Add("client_id", this.Parent.ClientId);
            apiRequest.QueryValues.Add("response_type", request.ResponseType);
            apiRequest.QueryValues.Add("redirect_uri", request.RedirectURI);
            apiRequest.QueryValues.Add("scope", request.Scope);
            apiRequest.QueryValues.Add("force_verify", request.ForceVerify);
            apiRequest.QueryValues.Add("state", request.State);

            using (var response = this.Parent.Request(apiRequest))
            {
                return response.Impl.ResponseUri.AbsoluteUri;
            }

        }

        public AuthenticationResult GetAuthenticationResult(Uri responseURI, OAuthRequestCode request)
        {
            QueryValues queryValues = null;
            AuthenticationResult result = null;

            if (request is OAuthRequestAuthorizationCode auth)
            {
                queryValues = QueryValues.Parse(StringUtils.RemovePrefix(responseURI.Query, "?"));
                this.EnsureStateEquals(queryValues, request);

                var accessTokenRequest = new OAuthTokenRequest();
                accessTokenRequest.ClientSecret = auth.ClientSecret;
                accessTokenRequest.Code = queryValues.Single("code");
                accessTokenRequest.GrantType = "authorization_code";
                accessTokenRequest.RedirectURI = auth.RedirectURI;
                result = this.GetAuthenticationResult(accessTokenRequest);
            }
            else if (request is OAuthRequestTokenCode)
            {
                queryValues = QueryValues.Parse(StringUtils.RemovePrefix(responseURI.Fragment, "#"));
                this.EnsureStateEquals(queryValues, request);

                result = new AuthenticationResult(queryValues);
            }
            else
            {
                throw new ArgumentException("Invalid OAuthRequest Type", nameof(request));
            }

            return result;
        }

        public void EnsureStateEquals(QueryValues queryValues, OAuthRequestCode request)
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

        public AuthenticationResult GetAuthenticationResult(OAuthRequestClientCredentials request)
        {
            var tokenRequest = new OAuthTokenRequest();
            tokenRequest.ClientSecret = request.ClientSecret;
            tokenRequest.GrantType = "client_credentials";
            tokenRequest.Scope = request.Scope;

            return this.GetAuthenticationResult(tokenRequest);
        }

        public AuthenticationResult GetAuthenticationResult(OAuthTokenRequest request)
        {
            var apiRequest = new TwitchAPIRequest();
            apiRequest.BaseURL = "https://id.twitch.tv/oauth2/token";
            apiRequest.Method = "POST";
            apiRequest.QueryValues.Add("client_id", this.Parent.ClientId);
            apiRequest.QueryValues.Add("client_secret", request.ClientSecret);
            apiRequest.QueryValues.Add("code", request.Code);
            apiRequest.QueryValues.Add("grant_type", request.GrantType);
            apiRequest.QueryValues.Add("redirect_uri", request.RedirectURI);
            apiRequest.QueryValues.Add("scope", request.Scope);
            var jToken = this.Parent.RequestAsJson(apiRequest, "status");

            return new AuthenticationResult(jToken);
        }

        public AuthenticationResult RefreshAccessTokens(string refreshToken, string clientSecret)
        {
            var apiRequest = new TwitchAPIRequest();
            apiRequest.BaseURL = "https://id.twitch.tv/oauth2/token";
            apiRequest.Method = "POST";
            apiRequest.QueryValues.Add("grant_type", "refresh_token");
            apiRequest.QueryValues.Add("refresh_token", refreshToken);
            apiRequest.QueryValues.Add("client_id", this.Parent.ClientId);
            apiRequest.QueryValues.Add("client_secret", clientSecret);
            var jToken = this.Parent.RequestAsJson(apiRequest, "status");

            return new AuthenticationResult(jToken);
        }

    }

}
