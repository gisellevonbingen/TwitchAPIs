using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TwitchAPIs.Test
{
    public class TwitchAuthHandler : IDisposable
    {
        private TwitchAPI API;

        private Form Form;
        private WebBrowser Browser;

        private OAuthRequest Request;
        private Uri ResponseURI;

        public TwitchAuthHandler(TwitchAPI api)
        {
            this.API = api;

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

        public OAuthAuthorization Auth(OAuthRequest request)
        {
            var api = this.API;
            var authUri = api.Authorization.GetOAuthURI(request);

            this.Request = request;
            this.Browser.Navigate(authUri);

            Application.Run(this.Form);

            var responseURI = this.ResponseURI;

            if (responseURI != null)
            {
                var oAuth = api.Authorization.GetOAuthAuthorization(responseURI, request);
                return oAuth;
            }

            return null;
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

            if (url.AbsoluteUri.StartsWith(this.Request.RedirectURI) == true)
            {
                this.ResponseURI = url;
                this.Form.Close();
            }

        }

    }

}
