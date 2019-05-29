using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.Test
{
    public class UserConsole : UserAbstract
    {
        public object SyncRoot { get; }
        public StringBuilder ReadBuffer { get; set; }

        private string _ReadPrefix;
        public string ReadPrefix { get { return this._ReadPrefix; } set { this.UpdateReadPrefix(value); } }

        private int _CursorLeft;
        public int CursorLeft { get { return this._CursorLeft; } set { this.UpdateCursor(value); } }

        public UserConsole()
        {
            this.SyncRoot = new object();
            this.ReadBuffer = new StringBuilder();

            this._ReadPrefix = "> ";
            this._CursorLeft = 0;

            this.RefreshLine();
        }

        private void UpdateReadPrefix(string value)
        {
            lock (this.SyncRoot)
            {
                this._ReadPrefix = value;
                this.RefreshLine();
            }

        }

        public void UpdateCursor()
        {
            this.UpdateCursor(this.CursorLeft);
        }

        public void UpdateCursor(int newCursorLeft)
        {
            lock (this.SyncRoot)
            {
                var prefixLength = this.ReadPrefix.Length;
                var readBuffer = this.ReadBuffer.ToString();
                newCursorLeft = Math.Max(0, Math.Min(newCursorLeft, readBuffer.Length));

                this._CursorLeft = newCursorLeft;
                Console.CursorLeft = prefixLength + this.CursorLeft;
            }

        }

        protected void WriteLine(string str)
        {
            lock (this.SyncRoot)
            {
                this.ClearLine();

                Console.CursorLeft = 0;
                Console.WriteLine(str);

                this.WriteReadBuffer();
            }

        }

        protected void RefreshLine()
        {
            lock (this.SyncRoot)
            {
                this.ClearLine();
                this.WriteReadBuffer();
            }

        }

        protected void WriteReadBuffer()
        {
            Console.CursorLeft = 0;
            Console.Write(this.ReadPrefix + this.ReadBuffer);

            this.UpdateCursor();
        }

        public void ClearLine()
        {
            lock (this.SyncRoot)
            {
                var top = Console.CursorTop;

                Console.CursorLeft = 0;
                var bufferWidth = Console.BufferWidth;
                Console.Write(new string(' ', bufferWidth - 1));
                Console.CursorLeft = 0;
                Console.CursorTop = top;

                this.UpdateCursor();
            }

        }

        protected void WriteLine()
        {
            this.WriteLine(string.Empty);
        }

        public override void SendMessage()
        {
            this.WriteLine();
        }

        public void MoveCursorHead()
        {
            lock (this.SyncRoot)
            {
                this.CursorLeft = 0;
            }

        }

        public void MoveCursorTail()
        {
            lock (this.SyncRoot)
            {
                var builder = this.ReadBuffer;
                this.CursorLeft = builder.ToString().Length;
            }

        }

        public void Backspace()
        {
            lock (this.SyncRoot)
            {
                var left = this.CursorLeft;
                var builder = this.ReadBuffer;

                if (left > 0)
                {
                    builder.Remove(left - 1, 1);
                    this.CursorLeft--;
                    this.RefreshLine();
                }

            }

        }

        public void Delete()
        {
            lock (this.SyncRoot)
            {
                var left = this.CursorLeft;
                var builder = this.ReadBuffer;

                if (left < builder.Length)
                {
                    builder.Remove(left, 1);
                    this.RefreshLine();
                }

            }

        }

        public override string ReadInput()
        {
            var builder = this.ReadBuffer;
            builder.Clear();

            while (true)
            {
                var keyInfo = Console.ReadKey(true);
                var key = keyInfo.Key;

                lock (this.SyncRoot)
                {
                    if (key == ConsoleKey.Enter)
                    {
                        var input = builder.ToString();
                        builder.Clear();

                        this.WriteLine(this.ReadPrefix + input);
                        this.WriteLine();
                        this.CursorLeft = 0;

                        return input;
                    }
                    else if (key == ConsoleKey.LeftArrow)
                    {
                        this.CursorLeft--;
                    }
                    else if (key == ConsoleKey.RightArrow)
                    {
                        this.CursorLeft++;
                    }
                    else if (key == ConsoleKey.Home)
                    {
                        this.MoveCursorHead();
                    }
                    else if (key == ConsoleKey.End)
                    {
                        this.MoveCursorTail();
                    }
                    else if (key == ConsoleKey.UpArrow || key == ConsoleKey.DownArrow)
                    {

                    }
                    else if (key == ConsoleKey.Backspace)
                    {
                        this.Backspace();
                    }
                    else if (key == ConsoleKey.Delete)
                    {
                        this.Delete();
                    }
                    else
                    {
                        builder.Insert(this.CursorLeft, keyInfo.KeyChar);
                        this.CursorLeft++;
                        this.RefreshLine();
                    }

                }

            }

        }

        public override void SendMessage(string message)
        {
            this.WriteLine(message);
        }

    }

}
