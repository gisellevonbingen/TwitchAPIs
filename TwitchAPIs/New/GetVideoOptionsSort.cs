using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.New
{
    public class GetVideoOptionsSort : ValueEnum<string>
    {
        public static EnumRegister<GetVideoOptionsSort, string> Register { get; } = new EnumRegister<GetVideoOptionsSort, string>((o, n, v) => new GetVideoOptionsSort(o, n, v));

        public static GetVideoOptionsSort Time { get; } = Register.Generate(nameof(Time), "time");
        public static GetVideoOptionsSort Trending { get; } = Register.Generate(nameof(Trending), "trending");
        public static GetVideoOptionsSort Views { get; } = Register.Generate(nameof(Views), "views");

        private GetVideoOptionsSort(int ordinal, string name, string value) : base(ordinal, name, value)
        {

        }

    }

}

