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
        public string OAuthURI { get; private set; }
        public Uri ResponseURI { get; private set; }
        public OAuthAuthorization OAuthAuthorization { get; set; }

        private Form Form;
        private WebBrowser Browser;

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
            var authURI = this.OAuthURI = api.Authorization.GetOAuthURI(authRequest);

            var form = this.Form = new Form();
            var browser = this.Browser = new WebBrowser();
            browser.Navigated += this.OnBrowserNavigated;
            form.Controls.Add(browser);
            form.SizeChanged += this.OnFormResize;
            browser.Navigate(authURI);

            this.UpdateBrowserSize();

            Application.Run(form);

            var responseURI = this.ResponseURI;

            if (responseURI != null)
            {
                var oAuth = this.OAuthAuthorization = api.Authorization.GetOAuthAuthorization(responseURI, authRequest);
                api.AccessToken = oAuth.AccessToken;

                return true;
            }
            else
            {
                return false;
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

        private void OnFormResize(object sender, EventArgs e)
        {
            this.UpdateBrowserSize();
        }

        private void UpdateBrowserSize()
        {
            this.Browser.Size = this.Form.ClientSize;
        }

        private void OnBrowserNavigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            var browser = sender as WebBrowser;
            var url = browser.Url;
            this.User.SendMessage($"OnBrowserNavigated : {url}");

            if (url.AbsoluteUri.StartsWith(OAuthRequest.RedirectURI) == true)
            {
                this.ResponseURI = url;
                this.Form.Close();
            }

        }

    }

}
