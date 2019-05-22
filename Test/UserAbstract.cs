using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPI.Test
{
    public abstract class UserAbstract
    {
        public string BreakInput { get; set; }

        public UserAbstract()
        {
            this.BreakInput = ":break";
        }

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
            return this.QueryInput(message, names, false);
        }

        public virtual int QueryInput<T>(string message, T[] names, bool breakable)
        {
            var breakInput = this.BreakInput;
            return this.QueryInput(message, names, breakable, breakInput, $"Break to '{breakInput}'");
        }

        public virtual int QueryInput<T>(string message, T[] names, bool breakable, string breakInput, string breakMessage)
        {
            int digits = (int)(Math.Log10(names.Length) + 1);
            var format = "D" + digits;
            breakInput = breakInput ?? this.BreakInput;

            while (true)
            {
                for (int i = 0; i < names.Length; i++)
                {
                    var value = names[i];
                    this.SendMessage($"{i.ToString(format)} - {value}");
                }

                if (breakable == true)
                {
                    this.SendMessage(breakMessage);
                }

                string input = this.ReadInput(message);

                if (input.Equals(breakInput) == true)
                {
                    if (breakable == true)
                    {
                        return -1;
                    }

                }
                else if (int.TryParse(input, out int index) == true && 0 <= index && index < names.Length)
                {
                    return index;
                }

                this.SendMessage();
                continue;
            }

        }

    }

}
