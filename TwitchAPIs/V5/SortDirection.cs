using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.V5
{
    public class SortDirection : ValueEnum<string>
    {
        public static EnumRegister<SortDirection, string> Register { get; } = new EnumRegister<SortDirection, string>();

        public static SortDirection Desc { get; } = new SortDirection(nameof(Desc), "desc");
        public static SortDirection Asc { get; } = new SortDirection(nameof(Asc), "asc");

        private SortDirection(string name, string value) : base(name, value)
        {
            Register.Add(this);
        }

    }

}
