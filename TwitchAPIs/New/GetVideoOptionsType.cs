using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.New
{
    public class GetVideoOptionsType : ValueEnum<string>
    {
        public static EnumRegister<GetVideoOptionsType, string> Register { get; } = new EnumRegister<GetVideoOptionsType, string>((o, n, v) => new GetVideoOptionsType(o, n, v));

        public static GetVideoOptionsType All { get; } = Register.Generate(nameof(All), "all");
        public static GetVideoOptionsType Upload { get; } = Register.Generate(nameof(Upload), "upload");
        public static GetVideoOptionsType Archive { get; } = Register.Generate(nameof(Archive), "archive");
        public static GetVideoOptionsType Highlight { get; } = Register.Generate(nameof(Highlight), "highlight");

        private GetVideoOptionsType(int ordinal, string name, string value) : base(ordinal, name, value)
        {

        }

    }

}

