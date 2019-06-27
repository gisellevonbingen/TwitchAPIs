using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.V5
{
    public class SortDirection : ValueEnum<string>
    {
        public static EnumRegister<SortDirection, string> Register { get; } = new EnumRegister<SortDirection, string>((o, n, v) => new SortDirection(o, n, v));

        public static SortDirection Desc { get; } = Register.Generate(nameof(Desc), "desc");
        public static SortDirection Asc { get; } = Register.Generate(nameof(Asc), "asc");

        private SortDirection(int ordinal, string name, string value) : base(ordinal, name, value)
        {

        }

    }

}
