using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.Test
{
    public class UserConsole : UserAbstract
    {
        private Encoding _Encoding;
        private string _ReadPrefix;
        private int _CursorLeft;

        public object SyncRoot { get; }
        public StringBuilder ReadBuffer { get; set; }
        public Encoding Encoding { get { return this._Encoding; } set { this.UpdateEncoding(value); } }
        public string ReadPrefix { get { return this._ReadPrefix; } set { this.UpdateReadPrefix(value); } }
        public int CursorLeft { get { return this._CursorLeft; } set { this.UpdateCursor(value); } }

        public UserConsole()
        {
            this._Encoding = Console.InputEncoding;
            this._ReadPrefix = "> ";
            this._CursorLeft = 0;

            this.SyncRoot = new object();
            this.ReadBuffer = new StringBuilder();

            this.RefreshLine();
        }

        protected virtual void UpdateEncoding(Encoding value)
        {
            lock (this.SyncRoot)
            {
                this._Encoding = value;
                Console.InputEncoding = value;
                Console.OutputEncoding = value;
            }

        }

        protected virtual void UpdateReadPrefix(string value)
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

        public virtual void UpdateCursor(int newCursorLeft)
        {
            lock (this.SyncRoot)
            {
                var prefixLength = this.ReadPrefix.Length;
                var readBuffer = this.ReadBuffer.ToString();
                newCursorLeft = Math.Max(0, Math.Min(newCursorLeft, readBuffer.Length));

                var bytesCount = this.Encoding.GetByteCount(readBuffer.ToCharArray(), 0, newCursorLeft);

                this._CursorLeft = newCursorLeft;
                Console.CursorLeft = prefixLength + bytesCount;
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
            lock (this.SyncRoot)
            {
                Console.CursorLeft = 0;
                Console.Write(this.ReadPrefix + this.ReadBuffer);

                this.UpdateCursor();
            }

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

        private void MoveCursorLeft(bool word)
        {
            lock (this.SyncRoot)
            {
                var cursor = this.CursorLeft;

                if (word == true)
                {
                    this.CursorLeft = this.GetPrevWordIndex(cursor);
                }
                else
                {
                    this.CursorLeft = cursor - 1;
                }

            }

        }

        private void MoveCursorRight(bool word)
        {
            lock (this.SyncRoot)
            {
                var cursor = this.CursorLeft;

                if (word == true)
                {
                    this.CursorLeft = this.GetNextWordIndex(cursor);
                }
                else
                {
                    this.CursorLeft = cursor + 1;
                }

            }

        }

        public int GetPrevWordIndex(int cursor)
        {
            lock (this.SyncRoot)
            {
                var readBuffer = this.ReadBuffer.ToString();

                if (cursor > 1)
                {
                    var index = readBuffer.LastIndexOf(' ', cursor - 2);

                    if (index != -1)
                    {
                        return index + 1;
                    }

                }

                return 0;
            }

        }

        public int GetNextWordIndex(int cursor)
        {
            lock (this.SyncRoot)
            {
                var readBuffer = this.ReadBuffer.ToString();

                if (cursor < readBuffer.Length)
                {
                    var index = readBuffer.IndexOf(' ', cursor + 1);

                    if (index != -1)
                    {
                        return index + 1;
                    }

                }

                return readBuffer.Length;
            }

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
                this.CursorLeft = this.ReadBuffer.Length;
            }

        }

        public void Backspace(bool word)
        {
            lock (this.SyncRoot)
            {
                var cursor = this.CursorLeft;
                var builder = this.ReadBuffer;

                if (word == true)
                {
                    var wordIndex = this.GetPrevWordIndex(cursor);
                    var count = cursor - wordIndex;
                    builder.Remove(wordIndex, count);
                    this.CursorLeft -= count;
                    this.RefreshLine();
                }
                else if (cursor > 0)
                {
                    builder.Remove(cursor - 1, 1);
                    this.CursorLeft--;
                    this.RefreshLine();
                }

            }

        }

        public void Delete(bool word)
        {
            lock (this.SyncRoot)
            {
                var cursor = this.CursorLeft;
                var builder = this.ReadBuffer;

                if (word == true)
                {
                    var wordIndex = this.GetNextWordIndex(cursor);
                    var count = wordIndex - cursor;
                    builder.Remove(cursor, count);
                    this.RefreshLine();
                }
                else if (cursor < builder.Length)
                {
                    builder.Remove(cursor, 1);
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
                var control = keyInfo.Modifiers.HasFlag(ConsoleModifiers.Control);

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
                        this.MoveCursorLeft(control);
                    }
                    else if (key == ConsoleKey.RightArrow)
                    {
                        this.MoveCursorRight(control);
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
                        this.Backspace(control);
                    }
                    else if (key == ConsoleKey.Delete)
                    {
                        this.Delete(control);
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
