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

        private AuthorizeRequest AuthorizeRequest;
        private string AuthorizationURI;

        private NameValueCollection Query;

        public AuthorizeTest(ConsoleUser user, TwitchCrawler crawler) : base(user, crawler)
        {
            var authorizeRequest = this.AuthorizeRequest = new AuthorizeRequest();
            authorizeRequest.RedirectURI = user.ReadInput("RedirectURI");
            authorizeRequest.Scope = "chat:read";
            authorizeRequest.ForceVerify = true;
            authorizeRequest.State = Guid.NewGuid().ToString().Replace("-", "");
            var authorizationURI = this.AuthorizationURI = crawler.GetAuthorizeURI(authorizeRequest);

            Application.SetCompatibleTextRenderingDefault(false);
            Application.EnableVisualStyles();

            var form = this.Form = new Form();
            var browser = this.Browser = new WebBrowser();
            browser.Navigated += this.OnBrowserNavigated;
            form.Controls.Add(browser);
            form.SizeChanged += this.OnFormResize;
            browser.Navigate(authorizationURI);

            this.UpdateBrowserSize();

            Application.Run(form);

            var query = this.Query;

            if (query != null)
            {
                if (authorizeRequest.State.Equals(query["state"]) == false)
                {
                    this.User.SendMessage($"Invalid State : {authorizeRequest.State} vs {query["state"]}");
                    return;
                }

                var accessTokenRequest = new AccessTokenRequest() { };
                accessTokenRequest.ClientSecret = user.ReadInput("Client-Secret");
                accessTokenRequest.Code = query["code"];
                accessTokenRequest.RedirectURI = authorizeRequest.RedirectURI;
                var authorization = this.Crawler.GetAccessToken(accessTokenRequest);
                Console.WriteLine($"AccessToken = {authorization.AccessToken}");
                Console.WriteLine($"RefreshToken = {authorization.RefreshToken}");
                Console.WriteLine($"ExpiresIn = {authorization.ExpiresIn}");
                Console.WriteLine($"Scope = [{string.Join(", ", authorization.Scope)}]");
                Console.WriteLine($"TokenType = {authorization.TokenType}");
            }

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

            if (url.AbsoluteUri.StartsWith(this.AuthorizeRequest.RedirectURI) == true)
            {
                this.Form.Close();
                this.Query = HttpUtility.ParseQueryString(url.Query);
            }

        }

    }

}
