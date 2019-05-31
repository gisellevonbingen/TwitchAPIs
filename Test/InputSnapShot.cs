using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.Test
{
    public class InputSnapShot
    {
        public string Text { get; }
        public int CursorLeft { get; }

        public InputSnapShot(string text, int cursorLeft)
        {
            this.Text = text;
            this.CursorLeft = cursorLeft;
        }

    }

}
