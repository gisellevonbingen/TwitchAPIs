using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Giselle.Commons;
using Newtonsoft.Json.Linq;

namespace TwitchAPIs
{
    public class TwitchBitTier
    {
        public int MinBits { get; set; }
        public string Id { get; set; }
        public string Color { get; set; }
        public Dictionary<string, Dictionary<string, Dictionary<string, string>>> Images { get; }
        public bool CanCheer { get; set; }

        public TwitchBitTier()
        {
            this.Images = new Dictionary<string, Dictionary<string, Dictionary<string, string>>>();
        }

        public TwitchBitTier Read(JToken jToken)
        {
            this.MinBits = jToken.Value<int>("min_bits");
            this.Id = jToken.Value<string>("id");
            this.Color = jToken.Value<string>("color");
            this.CanCheer = jToken.Value<bool>("can_cheer");

            DictionaryUtils.ClearAndPutAll(this.Images, jToken.ReadMap("images", (bk, bt) => new KeyValuePair<string, Dictionary<string, Dictionary<string, string>>>(bk, bt.ReadMap((sk, st) => new KeyValuePair<string, Dictionary<string, string>>(sk, st.ReadMap((s2k, s2t) => new KeyValuePair<string, string>(s2k, s2t.Value<string>())))))));

            return this;
        }

        public string GetImage(string background, string state, string scale)
        {
            if (this.Images.TryGetValue(background, out var stateMap) == true)
            {
                if (stateMap.TryGetValue(state, out var scaleMap) == true)
                {
                    if (scaleMap.TryGetValue(scale, out var image) == true)
                    {
                        return image;
                    }

                }

            }

            return null;
        }

    }

}
