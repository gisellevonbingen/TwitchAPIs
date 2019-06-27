using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.New
{
    public class GetVideoOptionsSort : ValueEnum<string>
    {
        public static EnumRegister<GetVideoOptionsSort> Register { get; } = new EnumRegister<GetVideoOptionsSort>();

        public static GetVideoOptionsSort Time { get; } = new GetVideoOptionsSort(nameof(Time), "time");
        public static GetVideoOptionsSort Trending { get; } = new GetVideoOptionsSort(nameof(Trending), "trending");
        public static GetVideoOptionsSort Views { get; } = new GetVideoOptionsSort(nameof(Views), "views");

        private GetVideoOptionsSort(string name, string value) : base(name, value)
        {
            Register.Add(this);
        }

    }

}
