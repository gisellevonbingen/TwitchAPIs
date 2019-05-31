using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.Test
{
    public class InputSnapShot
    {
        public InputEditType Type { get; set; }
        public string Text { get; set; }
        public int CursorLeft { get; set; }

        public InputSnapShot(InputEditType type, string text, int cursorLeft)
        {
            this.Type = type;
            this.Text = text;
            this.CursorLeft = cursorLeft;
        }

    }

}
