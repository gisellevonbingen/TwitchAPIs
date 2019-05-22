using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPI.Test
{
    public abstract class AbstractTest
    {
        public ConsoleUser User { get; }
        public TwitchCrawler Crawler { get; }

        public AbstractTest(ConsoleUser user, TwitchCrawler crawler)
        {
            this.User = user;
            this.Crawler = crawler;
        }

    }

}
