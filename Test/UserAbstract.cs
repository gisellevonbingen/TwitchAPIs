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

        public virtual int QueryInput<T>(string message, T[] names)
        {
            while (true)
            {
                for (int i = 0; i < names.Length; i++)
                {
                    var value = names[i];
                    this.SendMessage($"{i} - {value}");
                }

                if (int.TryParse(this.ReadInput(message), out int input) == true && (0 <= input && input < names.Length))
                {
                    return input;
                }
                else
                {
                    this.SendMessage();
                    continue;
                }

            }

        }

    }

}
