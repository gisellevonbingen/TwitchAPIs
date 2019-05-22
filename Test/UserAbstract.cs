using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPI.Test
{
    public abstract class UserAbstract
    {
        public abstract void SendMessage();

        public abstract void SendMessage(string message);

        public virtual void SendMessage(IEnumerable<string> messages)
        {
            foreach (var message in messages)
            {
                this.SendMessage(message);
            }

        }

        public abstract string ReadInput(string message);

    }

}
