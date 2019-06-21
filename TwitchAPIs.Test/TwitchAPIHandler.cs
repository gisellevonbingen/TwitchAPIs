using Giselle.Commons;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using TwitchAPIs.Authentication;

namespace TwitchAPIs.Test
{
    public class TwitchAPIHandler
    {
        private UserAbstract User;

        public TwitchAPI API { get; private set; }
        public OAuthRequest OAuthRequest { get; private set; }
        public AuthenticationResult AuthenticationResult { get; set; }

        public TwitchAPIHandler(UserAbstract user)
        {
            this.User = user;
        }

        public bool Create()
        {
            var user = this.User;
            var clientId = user.ReadInput("Enter Client-ID");
            var api = this.API = new TwitchAPI();
            api.ClientId = clientId;

            var authRequest = this.OAuthRequest = this.CreateOAuthRequest(user);

            if (authRequest != null)
            {
                using (var authHandler = new TwitchAuthHandler(api))
                {
                    var result = this.AuthenticationResult = authHandler.Auth(authRequest);

                    if (result != null)
                    {
                        api.AccessToken = result.AccessToken;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }

            }
            else
            {
                return true;
            }

        }

        private OAuthRequest CreateOAuthRequest(UserAbstract user)
        {
            var list = new List<OAuthRequest>();
            list.Add(null);
            list.Add(new OAuthRequestTokenCode());
            list.Add(new OAuthRequestAuthorizationCode());
            list.Add(new OAuthRequestClientCredentials());

            var request = user.QueryInput("Enter RequestType", list, req => req == null ? "Not Auth" : req.GetType().Name).Value;

            if (request == null)
            {
                return null;
            }

            request.Scopes.AddRange(user.ReadInput($"Enter Scopes, '{OAuthRequest.ScopeSeparater}' separated").Split(OAuthRequest.ScopeSeparater));

            if (request is OAuthRequestAuthorizationCode auth)
            {
                auth.ClientSecret = user.ReadInput("Enter Client-Secret");
            }
            else if (request is OAuthRequestClientCredentials client)
            {
                client.ClientSecret = user.ReadInput("Enter Client-Secret");
            }

            if (request is OAuthRequestCode code)
            {
                code.RedirectUri = user.ReadInput("Enter Redirect Uri");
                code.ForceVerify = false;
                code.State = Guid.NewGuid().ToString().Replace("-", "");
            }

            return request;
        }

    }

}
