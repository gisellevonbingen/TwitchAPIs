using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.Test
{
    public abstract class UserAbstract
    {
        public string BreakInput { get; set; }
        public string ReturnInput { get; set; }

        public UserAbstract()
        {
            this.BreakInput = ":break";
            this.ReturnInput = ":return";
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

        public abstract string ReadInput();

        public virtual string ReadInput(string message)
        {
            this.SendMessage(message);

            return this.ReadInput();
        }

        public virtual int QueryInput<T>(string message, IEnumerable<T> collection)
        {
            return this.QueryInput(message, collection, false);
        }

        public virtual int QueryInput<T>(string message, IEnumerable<T> collection, bool breakable)
        {
            var breakInput = this.BreakInput;
            return this.QueryInput(message, collection, breakable, $"Break to '{breakInput}'", breakInput);
        }

        public virtual int QueryInput<T>(string message, IEnumerable<T> collection, bool breakable, string breakMessage)
        {
            var breakInput = this.BreakInput;
            return this.QueryInput(message, collection, breakable, breakMessage, breakInput);
        }

        public virtual int QueryInput<T>(string message, IEnumerable<T> collection, bool breakable, string breakMessage, string breakInput)
        {
            var arry = collection.ToArray();
            int digits = Math.Max((int)(Math.Log10(arry.Length - 1) + 1), 0);
            var format = "D" + digits;
            breakInput = breakInput ?? this.BreakInput;

            while (true)
            {
                for (int i = 0; i < arry.Length; i++)
                {
                    var value = arry[i];
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
                else if (int.TryParse(input, out int index) == true && 0 <= index && index < arry.Length)
                {
                    return index;
                }

                this.SendMessage();
                continue;
            }

        }

    }

}
