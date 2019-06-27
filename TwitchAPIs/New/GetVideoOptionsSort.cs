using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.New
{
    public class GetVideoOptionsSort
    {
        private static List<GetVideoOptionsSort> List { get; } = new List<GetVideoOptionsSort>();
        public static GetVideoOptionsSort[] Values => List.ToArray();

        public static GetVideoOptionsSort Time { get; } = new GetVideoOptionsSort(nameof(Time), "time");
        public static GetVideoOptionsSort Trending { get; } = new GetVideoOptionsSort(nameof(Trending), "trending");
        public static GetVideoOptionsSort Views { get; } = new GetVideoOptionsSort(nameof(Views), "views");

        public string Name { get; }
        public string Value { get; }

        private GetVideoOptionsSort(string name, string value)
        {
            this.Name = name;
            this.Value = value;

            List.Add(this);
        }

    }

}
