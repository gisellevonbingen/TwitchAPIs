using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs
{
    public interface ValueEnum
    {
        int Ordinal { get; }
        string Name { get; }
    }

    public class ValueEnum<T> : ValueEnum
    {
        public int Ordinal { get; }
        public string Name { get; }
        public T Value { get; }

        protected ValueEnum(int ordinal, string name, T value)
        {
            this.Ordinal = ordinal;
            this.Name = name;
            this.Value = value;
        }

        public override string ToString()
        {
            return this.Name;
        }

    }

}
