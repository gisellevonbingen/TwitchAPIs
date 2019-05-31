using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.Test
{
    public class InputEditHistory
    {
        public List<InputSnapShot> History { get; }
        public int Cursor { get; private set; }

        public InputEditHistory()
        {
            this.History = new List<InputSnapShot>();
            this.Cursor = -1;

            this.Clear();
        }

        public InputSnapShot Feach()
        {
            return this.Feach(this.Cursor);
        }

        public InputSnapShot Feach(int cursor)
        {
            var history = this.History;

            if (0 <= cursor && cursor < history.Count)
            {
                return history[cursor];
            }
            else
            {
                return null;
            }

        }

        public InputSnapShot Prev()
        {
            this.Cursor = Math.Max(0, this.Cursor - 1);
            return this.Feach();
        }

        public InputSnapShot Next()
        {
            this.Cursor = Math.Min(this.History.Count - 1, this.Cursor + 1);
            return this.Feach();
        }

        public void Clear()
        {
            this.History.Clear();
            this.Cursor = -1;
        }

        public void Record(string input, int cursorLeft)
        {
            var history = this.History;
            var cursor = this.Cursor;

            var startIndex = cursor + 1;
            var endIndex = history.Count;
            var removeCount = endIndex - startIndex;
            history.RemoveRange(startIndex, removeCount);

            history.Add(new InputSnapShot(input, cursorLeft));
            this.Cursor = history.Count - 1;
        }

    }

}
