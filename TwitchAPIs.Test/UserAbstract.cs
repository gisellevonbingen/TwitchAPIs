﻿using System;
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

        protected abstract string OnReadInput();

        public virtual string ReadInput()
        {
            var input = this.OnReadInput();
            var returnInput = this.ReturnInput;

            if (input.Equals(returnInput) == true)
            {
                throw new UserInputReturnException();
            }

            return input;
        }

        public virtual string ReadInput(string message)
        {
            this.SendMessage(message);

            return this.ReadInput();
        }

        public virtual QueryResult<T> QueryInput<T>(string message, IEnumerable<T> collection, Func<T, string> func)
        {
            return this.QueryInput(message, collection, func, false);
        }

        public virtual QueryResult<T> QueryInput<T>(string message, IEnumerable<T> collection, Func<T, string> func, bool breakable)
        {
            var breakInput = this.BreakInput;
            return this.QueryInput(message, collection, func, breakable, $"Break to '{breakInput}'", breakInput);
        }

        public virtual QueryResult<T> QueryInput<T>(string message, IEnumerable<T> collection, Func<T, string> func, bool breakable, string breakMessage)
        {
            var breakInput = this.BreakInput;
            return this.QueryInput(message, collection, func, breakable, breakMessage, breakInput);
        }

        public virtual QueryResult<T> QueryInput<T>(string message, IEnumerable<T> collection, Func<T, string> func, bool breakable, string breakMessage, string breakInput)
        {
            var array = collection.ToArray();
            int digits = Math.Max((int)(Math.Log10(array.Length - 1) + 1), 0);
            var format = "D" + digits;
            breakInput = breakInput ?? this.BreakInput;

            while (true)
            {
                for (int i = 0; i < array.Length; i++)
                {
                    var value = array[i];
                    var text = func?.Invoke(value) ?? string.Concat(value);
                    this.SendMessage($"{i.ToString(format)} - {text}");
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
                        return new QueryResult<T>(-1, default, true);
                    }

                }
                else if (int.TryParse(input, out int index) == true && 0 <= index && index < array.Length)
                {
                    return new QueryResult<T>(index, array[index], false);
                }

                this.SendMessage();
                continue;
            }

        }

    }

}
