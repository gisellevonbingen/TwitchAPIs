using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TwitchAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var streamers = new List<string> { };
            string clientId = "";

            foreach (var streamer in streamers)
            {
                var crawler = new TwitchCrawler(clientId);
                var user = crawler.GetUser(streamer);

                var list = new List<string>();
                string cursor = null;

                Console.WriteLine("START : " + user.DisplayName);

                while (true)
                {
                    var follows = crawler.GetUserFollows(user.Id, cursor);
                    list.AddRange(follows.Followers.Select(u => u.DisplayName));
                    cursor = follows.Cursor;

                    Console.WriteLine("Cursor : " + follows.Cursor);

                    if (follows.Cursor == null)
                    {
                        break;
                    }

                    Thread.Sleep(1000);
                }

                File.WriteAllLines("result/" + streamer + ".txt", list);
            }

        }

    }

}
