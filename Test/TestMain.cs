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
    public class TestMain
    {
        [STAThread]
        public static void Main(string[] args)
        {
            new TestMain();
        }

        public AbstractUser User { get; private set; }

        public TwitchCrawler Crawler { get; private set; }
        public OAuthRequest OAuthRequest { get; private set; }
        public string OAuthURI { get; private set; }
        public Uri ResponseURI { get; private set; }
        public OAuthAuthorization OAuthAuthorization { get; set; }

        private Form Form;
        private WebBrowser Browser;

        public TestMain()
        {
            var user = this.User = new ConsoleUser();

            var clientId = user.ReadInput("Enter Client-ID");
            var crawler = this.Crawler = new TwitchCrawler(clientId);
            var authRequest = this.OAuthRequest = this.CreateOAuthRequest(user);
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

            if (responseURI == null)
            {
                user.SendMessage($"What's wrong?");
                return;
            }

            var authorization = this.OAuthAuthorization = crawler.GetOAuthAuthorization(responseURI, authRequest);
            this.PrintAuthoriztion(user, authorization);

            var tests = new List<TestAbstract>();
            tests.Add(new TestRefreshOAuthAuthorization());

            while (true)
            {
                user.SendMessage();
                user.SendMessage();

                for (int i = 0; i < tests.Count; i++)
                {
                    var test = tests[i];
                    user.SendMessage($"{i} - {test.GetType().Name}");
                }

                if (int.TryParse(user.ReadInput("Enter Test number"), out int input) == true && (0 <= input && input <= tests.Count))
                {
                    var test = tests[input];
                    user.SendMessage("Test - " + test.GetType().Name);
                    test.Run(this);
                }
                else
                {
                    continue;
                }

            }

        }

        public void PrintAuthoriztion(AbstractUser user, OAuthAuthorization authorization)
        {
            user.SendMessage();
            user.SendMessage("== OAuthAuthorization ==");
            user.SendMessage($"    AccessToken = {authorization.AccessToken}");
            user.SendMessage($"    RefreshToken = {authorization.RefreshToken}");
            user.SendMessage($"    ExpiresIn = {authorization.ExpiresIn}");
            user.SendMessage($"    Scope = [{string.Join(", ", authorization.Scope)}]");
            user.SendMessage($"    TokenType = {authorization.TokenType}");
        }

        private OAuthRequest CreateOAuthRequest(AbstractUser user)
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
