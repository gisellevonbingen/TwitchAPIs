using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPI.Test
{
    public class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            var user = new ConsoleUser();

            var clientId = user.ReadInput("Client-ID");
            var crawler = new TwitchCrawler(clientId);

            new AuthorizeTest(user, crawler);
        }

    }

}
