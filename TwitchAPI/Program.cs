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
            var logins = new List<string> {  };
            string clientId = "";

            var crawler = new TwitchCrawler(clientId);
            var requests = logins.Select(v => new UserRequest(UserType.Login, v)).ToArray();
            var users = crawler.GetUsers(requests);

            foreach (var user in users)
            {
                Console.WriteLine("=======");
                Console.WriteLine(user.Id);
                Console.WriteLine(user.Login);
                Console.WriteLine(user.DisplayName);
            }

        }

    }

}
