using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.Test
{
    public class InputEditHistory
    {
        private List<InputSnapShot> History;
        private int Cursor;

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
            this.Cursor = Math.Max(-1, this.Cursor - 1);
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

        public void Record(InputEditType type, string text, int cursorLeft)
        {
            var history = this.History;
            var cursor = this.Cursor;

            var startIndex = cursor + 1;
            var endIndex = history.Count;
            var removeCount = endIndex - startIndex;
            history.RemoveRange(startIndex, removeCount);

            var prev = this.GetPrevIfTypeEquals(type, cursor);

            if (prev != null)
            {
                prev.Text = text;
                prev.CursorLeft = cursorLeft;
            }
            else
            {
                history.Add(new InputSnapShot(type, text, cursorLeft));
                this.Cursor = history.Count - 1;
            }

        }

        private InputSnapShot GetPrevIfTypeEquals(InputEditType type, int cursor)
        {
            InputSnapShot prev = null;

            if (cursor > -1)
            {
                var cursored = this.History[cursor];

                if (cursored.Type == type)
                {
                    prev = cursored;
                }

            }

            return prev;
        }
    }

}
