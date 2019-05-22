using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace TwitchAPI.Test
{
    public class AuthorizeTest : AbstractTest
    {
        private Form Form;
        private WebBrowser Browser;

        private OAuthRequest OAuthRequest;
        private string OAuthURI;

        private Uri ResponseURI;

        public AuthorizeTest(ConsoleUser user, TwitchCrawler crawler) : base(user, crawler)
        {
            var authRequest = this.OAuthRequest = this.CreateRequest(user);
            var authURI = this.OAuthURI = crawler.GetOAuthURI(authRequest);

            Application.SetCompatibleTextRenderingDefault(false);
            Application.EnableVisualStyles();

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
                var authorization = this.Crawler.GetOAuthAuthorization(responseURI, authRequest);
                user.SendMessage($"AccessToken = {authorization.AccessToken}");
                user.SendMessage($"RefreshToken = {authorization.RefreshToken}");
                user.SendMessage($"ExpiresIn = {authorization.ExpiresIn}");
                user.SendMessage($"Scope = [{string.Join(", ", authorization.Scope)}]");
                user.SendMessage($"TokenType = {authorization.TokenType}");
            }
            else
            {
                user.SendMessage($"What's wrong?");
            }

        }

        private OAuthRequest CreateRequest(ConsoleUser user)
        {
            var map = new Dictionary<int, OAuthRequest>();
            map[1] = new OAuthRequestToken();
            map[2] = new OAuthRequestAuthorization();

            OAuthRequest request = null;

            while (true)
            {
                foreach (var pair in map)
                {
                    user.SendMessage($"{pair.Key} - {pair.Value.GetType().Name}");
                }

                if (int.TryParse(user.ReadInput("RequestType"), out int input) == true && map.TryGetValue(input, out request))
                {
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
                auth.ClientSecret = user.ReadInput("Client-Secret");
            }

            request.RedirectURI = user.ReadInput("RedirectURI");
            request.Scope = "chat:read";
            request.ForceVerify = true;
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
