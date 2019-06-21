using Giselle.Commons;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.Authentication
{
    public class AuthenticationResult
    {
        public string AccessToken { get; set; }

        public string RefreshToken { get; set; }

        public int ExpiresIn { get; set; }

        public string[] Scopes { get; set; }

        public string TokenType { get; set; }

        public AuthenticationResult()
        {

        }


        public AuthenticationResult(QueryValues values)
        {
            this.AccessToken = values.Single("access_token");
            this.RefreshToken = values.Single("refresh_token");
            this.ExpiresIn = NumberUtils.ToInt(values.Single("expires_in"));
            var scope = values.Single("scope");
            this.Scopes = string.IsNullOrWhiteSpace(scope) ? null : scope.Split(' ');
            this.TokenType = values.Single("token_type");
        }

        public AuthenticationResult(JToken jToken)
        {
            this.AccessToken = jToken.Value<string>("access_token");
            this.RefreshToken = jToken.Value<string>("refresh_token");
            this.ExpiresIn = jToken.Value<int>("expires_in");
            this.Scopes = jToken.ArrayValues<string>("scope")?.ToArray();
            this.TokenType = jToken.Value<string>("token_type");
        }

    }

}
