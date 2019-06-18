using Giselle.Commons;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.OAuth
{
    public class OAuthAuthorization
    {
        public string AccessToken { get; set; }

        public string RefreshToken { get; set; }

        public int ExpiresIn { get; set; }

        public string[] Scope { get; set; }

        public string TokenType { get; set; }

        public OAuthAuthorization()
        {

        }


        public OAuthAuthorization(QueryValues values)
        {
            this.AccessToken = values.Single("access_token");
            this.RefreshToken = values.Single("refresh_token");
            this.ExpiresIn = NumberUtils.ToInt(values.Single("expires_in"));
            var scope = values.Single("scope");
            this.Scope = string.IsNullOrWhiteSpace(scope) ? null : scope.Split(' ');
            this.TokenType = values.Single("token_type");
        }

        public OAuthAuthorization(JToken jToken)
        {
            this.AccessToken = jToken.Value<string>("access_token");
            this.RefreshToken = jToken.Value<string>("refresh_token");
            this.ExpiresIn = jToken.Value<int>("expires_in");
            this.Scope = jToken.ArrayValues<string>("scope")?.ToArray();
            this.TokenType = jToken.Value<string>("token_type");
        }

    }

}
