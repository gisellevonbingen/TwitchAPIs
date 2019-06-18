using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.New
{
    public class TwitchTopGames
    {
        public TwitchGame[] Games { get; set; }
        public string Cursor { get; set; }
    }

}
