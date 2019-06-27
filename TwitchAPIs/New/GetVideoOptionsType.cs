using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.New
{
    public class GetVideoOptionsType
    {
        private static List<GetVideoOptionsType> List { get; } = new List<GetVideoOptionsType>();
        public static GetVideoOptionsType[] Values => List.ToArray();

        public static GetVideoOptionsType All { get; } = new GetVideoOptionsType(nameof(All), "all");
        public static GetVideoOptionsType Upload { get; } = new GetVideoOptionsType(nameof(Upload), "upload");
        public static GetVideoOptionsType Archive { get; } = new GetVideoOptionsType(nameof(Archive), "archive");
        public static GetVideoOptionsType Highlight { get; } = new GetVideoOptionsType(nameof(Highlight), "highlight");

        public string Name { get; }
        public string Value { get; }

        private GetVideoOptionsType(string name, string value)
        {
            this.Name = name;
            this.Value = value;

            List.Add(this);
        }

    }

}
