using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TwitchAPI.Test
{
    public class TwitchAuthHandler : IDisposable
    {
        private UserAbstract User;

        private Form Form;
        private WebBrowser Browser;

        private OAuthRequest Request;
        private Uri ResponseURI;

        public TwitchAuthHandler(UserAbstract user)
        {
            this.User = user;

            var form = this.Form = new Form();
            var browser = this.Browser = new WebBrowser();
            browser.Navigated += this.OnBrowserNavigated;
            form.Controls.Add(browser);
            form.SizeChanged += this.OnFormResize;

            this.UpdateBrowserSize();

        }

        ~TwitchAuthHandler()
        {
            this.Dispose(false);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
            this.Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            ObjectUtils.DisposeQuietly(this.Form);
        }

        public Uri Auth(OAuthRequest request, string uri)
        {
            this.Request = request;
            this.Browser.Navigate(uri);

            Application.Run(this.Form);

            return this.ResponseURI;
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

            if (url.AbsoluteUri.StartsWith(this.Request.RedirectURI) == true)
            {
                this.ResponseURI = url;
                this.Form.Close();
            }

        }

    }

}
