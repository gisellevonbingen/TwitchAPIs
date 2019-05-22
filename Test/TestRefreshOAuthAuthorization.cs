using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPI.Test
{
    public class TestRefreshOAuthAuthorization : TestAbstract
    {
        public override void Run(TestMain main)
        {
            var user = main.User;
            var handler = main.TwitchAPIHandler;

            var crawler = handler.Crawler;
            var authRequest = handler.OAuthRequest;
            var authorization = handler.OAuthAuthorization;

            if (authorization.RefreshToken != null && authRequest is OAuthRequestAuthorization auth)
            {
                var oAuth = handler.OAuthAuthorization = crawler.RefreshOAuthAuthorization(authorization.RefreshToken, auth.ClientSecret);
                crawler.AccessToken = oAuth.AccessToken;

                main.PrintAuthoriztion();
            }

        }

    }

}
