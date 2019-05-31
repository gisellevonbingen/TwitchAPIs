using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.Test
{
    public class InputEditHistory : History<InputEditSnapshot>
    {
        public InputEditHistory()
            : base(-1)
        {

        }

        protected override void OnRecord(InputEditSnapshot value)
        {
            var cursor = this.Cursor;
            var prev = this.GetPrevIfTypeEquals(value.Type, cursor);

            if (prev != null)
            {
                prev.Text = value.Text;
                prev.CursorLeft = value.CursorLeft;
            }
            else
            {
                base.OnRecord(value);
            }

        }

        private InputEditSnapshot GetPrevIfTypeEquals(InputEditType type, int cursor)
        {
            if (cursor > -1)
            {
                var cursored = this.Feach(cursor);

                if (cursored.Type == type)
                {
                    return cursored;
                }

            }

            return null;
        }

    }

}
