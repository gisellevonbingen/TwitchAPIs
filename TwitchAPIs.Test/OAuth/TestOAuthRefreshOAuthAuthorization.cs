using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Giselle.Commons.Users;
using TwitchAPIs.Authentication;

namespace TwitchAPIs.Test.OAuth
{
    [TwitchAPITest("OAuth", "Authorization")]
    public class TestOAuthRefreshOAuthAuthorization : TestAbstract
    {
        public override void Run(TestMain main)
        {
            var user = main.User;
            var handler = main.TwitchAPIHandler;

            var api = handler.API;
            var authRequest = handler.OAuthRequest;
            var authorization = handler.AuthenticationResult;

            if (authorization.RefreshToken != null && authRequest is OAuthRequestAuthorizationCode auth)
            {
                var oAuth = handler.AuthenticationResult = api.Authentication.RefreshAccessTokens(authorization.RefreshToken, auth.ClientSecret);
                api.AccessToken = oAuth.AccessToken;

                user.SendMessageAsReflection("Refreshed OAuthAuthorization", oAuth);
            }

        }

    }

}
