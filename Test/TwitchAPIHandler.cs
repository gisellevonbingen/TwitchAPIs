using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace TwitchAPI.Test
{
    public class TwitchAPIHandler
    {
        private UserAbstract User;

        public TwitchAPI API { get; private set; }
        public OAuthRequest OAuthRequest { get; private set; }
        public OAuthAuthorization OAuthAuthorization { get; set; }

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

            using (var authHandler = new TwitchAuthHandler(user, api))
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

        private OAuthRequest CreateOAuthRequest(UserAbstract user)
        {
            var list = new List<OAuthRequest>();
            list.Add(new OAuthRequestToken());
            list.Add(new OAuthRequestAuthorization());

            var input = user.QueryInput("Enter RequestType", list.Select(req => req.GetType().Name));
            var request = list[input];

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
