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
            var authRequest = this.OAuthRequest = new OAuthRequest();
            authRequest.RedirectURI = user.ReadInput("RedirectURI");
            authRequest.ResponseType = OAuthResponseType.Token;
            authRequest.Scope = "chat:read";
            authRequest.ForceVerify = true;
            authRequest.State = Guid.NewGuid().ToString().Replace("-", "");
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
                var responseType = authRequest.ResponseType;
                NameValueCollection query = null;
                OAuthAuthorization authorization = null;

                if (responseType.Equals(OAuthResponseType.Authorization, StringComparison.OrdinalIgnoreCase) == true)
                {
                    query = this.ParseQueryString(responseURI.Query, "?");

                    var accessTokenRequest = new OAuthAccessTokenRequest();
                    accessTokenRequest.ClientSecret = user.ReadInput("Client-Secret");
                    accessTokenRequest.Code = query["code"];
                    accessTokenRequest.RedirectURI = authRequest.RedirectURI;
                    authorization = this.Crawler.GetOAuthAccessToken(accessTokenRequest);

                }
                else if (responseType.Equals(OAuthResponseType.Token, StringComparison.OrdinalIgnoreCase) == true)
                {
                    query = this.ParseQueryString(responseURI.Fragment, "#");
                    authorization = this.Crawler.ParseOAuthAuthorization(query);
                }
                else
                {
                    user.SendMessage($"Invalid Response Type : " + responseType);
                    return;
                }

                if (authRequest.State.Equals(query["state"]) == false)
                {
                    user.SendMessage($"Invalid State : {authRequest.State} vs {query["state"]}");
                    return;
                }

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

        private NameValueCollection ParseQueryString(string str, string prefix)
        {
            if (str.StartsWith(prefix) == true)
            {
                str = str.Substring(prefix.Length);
            }

            return HttpUtility.ParseQueryString(str);
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
