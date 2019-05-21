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
            var logins = new List<string> { };
            var clientId = Console.ReadLine();
            var secretKey = Console.ReadLine();

            var crawler = new TwitchCrawler(clientId, secretKey);
            var authorization = crawler.Authorize("user:read:broadcast");
            Console.WriteLine(authorization.AccessToken);

            authorization = crawler.RefreshAuthorize(authorization.AccessToken);
            Console.WriteLine(authorization.RefreshToken);

        }

    }

}
