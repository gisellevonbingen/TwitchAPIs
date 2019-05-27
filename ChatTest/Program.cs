using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TwitchAPI.Test;
using WebSocketSharp;

namespace TwitchAPI.ChatTest
{
    public class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            var user = new UserConsole();
            var authUser = args.Length > 0 ? new UserFile(args[0]) : (UserAbstract)user;
            var clientId = authUser.ReadInput("Client-Id");
            var redirectURI = authUser.ReadInput("Redirect-URI");
            var nickName = authUser.ReadInput("Nickname").ToLowerInvariant();

            var api = new TwitchAPI();
            api.ClientId = clientId;
            var authorization = Auth(api, redirectURI);
            api.AccessToken = authorization.AccessToken;

            //var chat = new TwitchChatIRC();
            var chat = new TwitchChatWebSocket();
            chat.ConnectMode = ConnectMode.Default;
            chat.Connect();

            chat.Send($"PASS oauth:{api.AccessToken}");
            chat.Send($"NICK {nickName}");


            new Thread(() =>
            {
                while (true)
                {
                    var str = Console.ReadLine();
                    chat.Send(str);
                }

            }).Start();

            new Thread(() =>
            {
                while (true)
                {
                    var str = chat.Receive();
                    Console.WriteLine(str);
                }

            }).Start();

        }
        private static OAuthAuthorization Auth(TwitchAPI api, string redirectURI)
        {
            using (var authHandler = new TwitchAuthHandler(api))
            {
                var authRequest = new OAuthRequestToken();
                authRequest.State = Guid.NewGuid().ToString().Replace("-", "");
                authRequest.RedirectURI = redirectURI;
                authRequest.Scope = "chat:edit+chat:read";

                return authHandler.Auth(authRequest);
            }

        }

    }

}
