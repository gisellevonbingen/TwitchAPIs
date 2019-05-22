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

        public TwitchCrawler Crawler { get; private set; }
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
            var crawler = this.Crawler = new TwitchCrawler(clientId);
            var authRequest = this.OAuthRequest = this.CreateOAuthRequest(user);
            var authURI = this.OAuthURI = crawler.GetOAuthURI(authRequest);

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
                this.OAuthAuthorization = crawler.GetOAuthAuthorization(responseURI, authRequest);
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

            OAuthRequest request = null;

            while (true)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    var req = list[i];
                    user.SendMessage($"{i} - {req.GetType().Name}");
                }

                if (int.TryParse(user.ReadInput("Enter RequestType"), out int input) == true && (0 <= input && input <= list.Count))
                {
                    request = list[input];
                    break;
                }
                else
                {
                    user.SendMessage();
                    continue;
                }

            }

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
