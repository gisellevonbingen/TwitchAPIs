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
        public AuthenticationResult OAuthAuthorization { get; set; }

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

            if (NumberUtils.ToBool(user.ReadInput("Enter Authentication Whether as bool")) == true)
            {
                using (var authHandler = new TwitchAuthHandler(api))
                {
                    var authRequest = this.OAuthRequest = this.CreateOAuthRequest(user);
                    var oAuth = this.OAuthAuthorization = authHandler.Auth(authRequest);

                    if (oAuth != null)
                    {
                        api.AccessToken = oAuth.AccessToken;
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
            list.Add(new OAuthRequestToken());
            list.Add(new OAuthRequestAuthorization());

            var request = user.QueryInput("Enter RequestType", list, req => req.GetType().Name).Value;

            if (request is OAuthRequestAuthorization auth)
            {
                auth.ClientSecret = user.ReadInput("Enter Client-Secret");
            }

            request.RedirectURI = user.ReadInput("Enter RedirectURI");
            request.Scope = user.ReadInput("Enter Scope");
            request.ForceVerify = false;
            request.State = Guid.NewGuid().ToString().Replace("-", "");

            return request;
        }

    }

}
