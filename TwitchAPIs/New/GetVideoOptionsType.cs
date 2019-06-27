using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.New
{
    public class GetVideoOptionsType : ValueEnum<string>
    {
        public static EnumRegister<GetVideoOptionsType> Register { get; } = new EnumRegister<GetVideoOptionsType>();

        public static GetVideoOptionsType All { get; } = new GetVideoOptionsType(nameof(All), "all");
        public static GetVideoOptionsType Upload { get; } = new GetVideoOptionsType(nameof(Upload), "upload");
        public static GetVideoOptionsType Archive { get; } = new GetVideoOptionsType(nameof(Archive), "archive");
        public static GetVideoOptionsType Highlight { get; } = new GetVideoOptionsType(nameof(Highlight), "highlight");

        private GetVideoOptionsType(string name, string value) : base(name, value)
        {
            Register.Add(this);
        }

    }

}
