using Giselle.Commons;
using Giselle.Commons.Web;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs
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

                authorization = new OAuthAuthorization();
                authorization.Read(queryValues);
            }
            else
            {
                throw new ArgumentException("Invalid OAuthRequest Type", nameof(request));
            }

            return authorization;
        }

        public OAuthAuthorization RefreshOAuthAuthorization(string refreshToken, string clientSecret)
        {
            var apiRequest = new TwitchAPIRequestParameter();
            apiRequest.BaseURL = "https://id.twitch.tv/oauth2/token";
            apiRequest.Method = "POST";
            apiRequest.QueryValues.Add("grant_type", "refresh_token");
            apiRequest.QueryValues.Add("refresh_token", refreshToken);
            apiRequest.QueryValues.Add("client_id", this.Parent.ClientId);
            apiRequest.QueryValues.Add("client_secret", clientSecret);
            var jToken = this.Parent.Request(apiRequest, "status");

            var value = new OAuthAuthorization();
            value.Read(jToken);

            return value;
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
            var apiRequest = new TwitchAPIRequestParameter();
            apiRequest.BaseURL = "https://id.twitch.tv/oauth2/token";
            apiRequest.Method = "POST";
            apiRequest.QueryValues.Add("client_id", this.Parent.ClientId);
            apiRequest.QueryValues.Add("client_secret", request.ClientSecret);
            apiRequest.QueryValues.Add("code", request.Code);
            apiRequest.QueryValues.Add("grant_type", "authorization_code");
            apiRequest.QueryValues.Add("redirect_uri", request.RedirectURI);
            var jToken = this.Parent.Request(apiRequest, "status");

            var value = new OAuthAuthorization();
            value.Read(jToken);

            return value;
        }

        public string GetOAuthURI(OAuthRequest request)
        {
            var url = "https://id.twitch.tv/oauth2/authorize";
            url += $"?client_id={this.Parent.ClientId}";
            url += $"&response_type={request.ResponseType}";
            url += $"&redirect_uri={request.RedirectURI}";
            url += $"&scope={request.Scope}";

            var forceVerify = request.ForceVerify;
            var state = request.State;

            if (forceVerify == true)
            {
                url += $"&force_verify={forceVerify.ToString().ToLowerInvariant()}";
            }

            if (string.IsNullOrWhiteSpace(state) == false)
            {
                url += $"&state={state}";
            }

            var req = new WebRequestParameter();
            req.URL = url;
            req.Method = "GET";

            using (var res = this.Parent.Web.Request(req))
            {
                return res.Impl.ResponseUri.AbsoluteUri;
            }

        }

    }

}
