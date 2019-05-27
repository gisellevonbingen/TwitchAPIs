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
        public static void Main(string[] args)
        {
            var user = new UserConsole();
            var clientId = user.ReadInput("Client-Id");
            var redirectURI = user.ReadInput("Redirect-URI");

            var api = new TwitchAPI();
            api.ClientId = clientId;

            var authRequest = new OAuthRequestToken();
            authRequest.RedirectURI = redirectURI;
            authRequest.Scope = "chat:edit+chat:read";
            authRequest.State = Guid.NewGuid().ToString().Replace("-", "");
            api.Authorization.GetOAuthURI(authRequest);

            var ws = new WebSocket("ws://irc-ws.chat.twitch.tv:80");
            ws.Log.Output = null;
            ws.OnMessage += OnMessage;
            ws.OnError += OnError;
            ws.Connect();

            ws.Send("CAP REQ :twitch.tv/tags twitch.tv/commands");
            ws.Send($"PASS {"oauth:"}");
            ws.Send($"NICK {"gisellevonbingen"}");

            Console.WriteLine("ReadyState : " + ws.ReadyState);

            new Thread(() =>
            {
                while (true)
                {
                    ws.Ping("tmi.twitch.tv");
                    Thread.Sleep(5000);
                }

            }).Start();

            while (true)
            {
                var command = Console.ReadLine();
                ws.Send(command);
            }

        }

        private static void OnError(object sender, WebSocketSharp.ErrorEventArgs e)
        {
            Console.WriteLine("ERROR : " + e.Message);
        }

        private static List<Tuple<char, string>> Split(string str)
        {
            var list = new List<Tuple<char, string>>();
            char mod = '\0';
            string prev = string.Empty;

            for (int i = 0; i < str.Length; i++)
            {
                var c = str[i];

                if (c == '@' || c == ':')
                {
                    if (mod != '\0')
                    {
                        if (prev.Length > 0)
                        {
                            list.Add(new Tuple<char, string>(mod, prev));
                        }

                    }

                    mod = c;
                    prev = string.Empty;
                }
                else
                {
                    prev += c;
                }

            }

            if (mod != '\0')
            {
                if (prev.Length > 0)
                {
                    list.Add(new Tuple<char, string>(mod, prev));
                }

            }

            return list;
        }

        private static void OnMessage(object sender, MessageEventArgs e)
        {
            Console.WriteLine($"'{e.Data}'");
            //var splited = Split(e.Data);

            //foreach (var str in splited)
            //{
            //    Console.WriteLine(str.Item1 + "-" + str.Item2);
            //}

        }

    }

}
