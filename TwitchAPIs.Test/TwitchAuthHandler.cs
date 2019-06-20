using Giselle.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TwitchAPIs.Authentication;

namespace TwitchAPIs.Test
{
    public class TwitchAuthHandler : IDisposable
    {
        private TwitchAPI API;

        private Form Form;
        private WebBrowser Browser;

        private OAuthRequestCode CodeRequest;
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

        public AuthenticationResult Auth(OAuthRequest request)
        {
            var api = this.API;

            if (request is OAuthRequestCode code)
            {
                var codeAuthorizeUri = api.Authentication.GetCodeAuthorizeUri(code);

                this.CodeRequest = code;
                this.Browser.Navigate(codeAuthorizeUri);

                Application.Run(this.Form);

                var responseURI = this.ResponseURI;

                if (responseURI != null)
                {
                    return api.Authentication.GetAuthenticationResult(responseURI, code);
                }

            }
            else if (request is OAuthRequestClientCredentials client)
            {
                return api.Authentication.GetAuthenticationResult(client);
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

            if (url.AbsoluteUri.StartsWith(this.CodeRequest.RedirectURI) == true)
            {
                this.ResponseURI = url;
                this.Form.Close();
            }

        }

    }

}
