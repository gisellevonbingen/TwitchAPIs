using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPI.Test
{
    public class ConsoleUser : AbstractUser
    {
        public override string ReadInput(string message)
        {
            Console.WriteLine(message);
            Console.Write("> ");

            var input = Console.ReadLine();

            Console.WriteLine();

            return input;
        }

        public override void SendMessage(string message)
        {
            Console.WriteLine(message);
        }

    }

}
