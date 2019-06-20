using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using TwitchAPIs.New;
using uhttpsharp;
using uhttpsharp.Handlers;
using uhttpsharp.Listeners;
using uhttpsharp.RequestProviders;

namespace TwitchAPIs.Webhooks
{
    public class Program : IHttpRequestHandler
    {
        public static void Main(string[] args)
        {
            using (var httpServer = new HttpServer(new HttpRequestProvider()))
            {
                // Normal port 80 :
                httpServer.Use(new TcpListenerAdapter(new TcpListener(IPAddress.Any, 9090)));
                httpServer.Use(new HttpRouter().With("userfollows", new Program()));
                httpServer.Use((context, next) =>
                {
                    context.Response = new HttpResponse(HttpResponseCode.NotFound, "404 Not Found", true);
                    return Task.Factory.GetCompleted();
                });

                httpServer.Start();

                Console.ReadLine();
            }

        }

        public Program()
        {

        }

        public Task Handle(IHttpContext context, Func<Task> next)
        {
            var request = context.Request;

            if (request.Method == HttpMethods.Get)
            {
                request.QueryString.TryGetByName("hub.challenge", out var hubChallenge);
                context.Response = new HttpResponse(HttpResponseCode.Ok, hubChallenge, true);

                Console.WriteLine($"hub.challenge = {hubChallenge}");
            }
            else if (request.Method == HttpMethods.Post)
            {
                var headers = request.Headers;
                headers.TryGetByName("Twitch-Notification-Id", out var notificationId);
                headers.TryGetByName("Twitch-Notification-Timestamp", out var notificationTimestamp);

                var json = Encoding.UTF8.GetString(request.Post.Raw);
                var jToken = JObject.Parse(json);

                var follows = jToken.ReadArray("data", t => new TwitchFollow(t));

                foreach (var follow in follows)
                {
                    Console.WriteLine($"From = {follow.FromId},{follow.FromName}");
                    Console.WriteLine($"To = {follow.ToId},{follow.ToName}");
                    Console.WriteLine($"DateTime = {follow.FollowedAt.ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss")}");
                }

                context.Response = new HttpResponse(HttpResponseCode.Ok, string.Empty, true);
            }

            return Task.Factory.GetCompleted();
        }

    }

}
