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
            NameValueCollection query = null;
            OAuthAuthorization authorization = null;

            if (request is OAuthRequestAuthorization auth)
            {
                query = HttpUtility2.ParseQueryString(responseURI.Query, "?");
                this.EnsureOAuthStateEquals(query, request);

                var accessTokenRequest = new OAuthAccessTokenRequest();
                accessTokenRequest.ClientSecret = auth.ClientSecret;
                accessTokenRequest.Code = query["code"];
                accessTokenRequest.RedirectURI = auth.RedirectURI;
                authorization = this.GetOAuthAuthorization(accessTokenRequest);
            }
            else if (request is OAuthRequestToken)
            {
                query = HttpUtility2.ParseQueryString(responseURI.Fragment, "#");
                this.EnsureOAuthStateEquals(query, request);

                authorization = new OAuthAuthorization();
                authorization.Read(query);
            }
            else
            {
                throw new ArgumentException("Invalid OAuthRequest Type", nameof(request));
            }

            return authorization;
        }

        public OAuthAuthorization RefreshOAuthAuthorization(string refreshToken, string clientSecret)
        {
            var url = $"https://id.twitch.tv/oauth2/token";
            url += $"?grant_type=refresh_token";
            url += $"&refresh_token={refreshToken}";
            url += $"&client_id={this.Parent.ClientId}";
            url += $"&client_secret={clientSecret}";

            using (var res = this.Parent.Request(url, "POST"))
            {
                var jToken = res.ReadAsJSON();
                this.Parent.EnsureNotError(jToken, "status", "message");

                var value = new OAuthAuthorization();
                value.Read(jToken);
                return value;
            }

        }

        public void EnsureOAuthStateEquals(NameValueCollection map, OAuthRequest request)
        {
            var requested = request.State;

            if (requested == null)
            {
                return;
            }

            var responsed = map["state"];

            if (requested.Equals(responsed) == false)
            {
                throw new TwitchException($"OAuth state mismatched - Request:{requested} vs Response:{responsed})");
            }

        }

        public OAuthAuthorization GetOAuthAuthorization(OAuthAccessTokenRequest request)
        {
            var url = $"https://id.twitch.tv/oauth2/token";
            url += $"?client_id={this.Parent.ClientId}";
            url += $"&client_secret={request.ClientSecret}";
            url += $"&code={request.Code}";
            url += $"&grant_type=authorization_code";
            url += $"&redirect_uri={request.RedirectURI}";

            using (var res = this.Parent.Request(url, "POST"))
            {
                var jToken = res.ReadAsJSON();
                this.Parent.EnsureNotError(jToken, "status", "message");

                var value = new OAuthAuthorization();
                value.Read(jToken);
                return value;
            }

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

            using (var res = this.Parent.Request(url, "GET"))
            {
                return res.Impl.ResponseUri.AbsoluteUri;
            }

        }

    }

}
