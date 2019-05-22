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

            var crawler = main.Crawler;
            var authRequest = main.OAuthRequest;
            var authorization = main.OAuthAuthorization;

            if (authorization.RefreshToken != null && authRequest is OAuthRequestAuthorization auth)
            {
                var refresh = main.OAuthAuthorization = crawler.RefreshOAuthAuthorization(authorization.RefreshToken, auth.ClientSecret);
                main.PrintAuthoriztion(user, refresh);
            }

        }

    }

}
