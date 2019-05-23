using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPI
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

        public OAuthAuthorization Read(NameValueCollection map)
        {
            this.AccessToken = map["access_token"];
            this.RefreshToken = map["refresh_token"];
            this.ExpiresIn = NumberUtils.ToInt(map["expires_in"]);
            this.Scope = new string[] { map["scope"] };
            this.TokenType = map["token_type"];

            return this;
        }

        public OAuthAuthorization Read(JToken jToken)
        {
            this.AccessToken = jToken.Value<string>("access_token");
            this.RefreshToken = jToken.Value<string>("refresh_token");
            this.ExpiresIn = jToken.Value<int>("expires_in");
            this.Scope = jToken.GetArrayValues<string>("scope")?.ToArray();
            this.TokenType = jToken.Value<string>("token_type");

            return this;
        }

    }

}
