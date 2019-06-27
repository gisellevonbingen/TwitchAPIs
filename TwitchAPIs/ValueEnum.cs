using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs
{
    public interface ValueEnum
    {
        string Name { get; }

    }

    public class ValueEnum<T> : ValueEnum
    {
        public string Name { get; }
        public T Value { get; }

        protected ValueEnum(string name, T value)
        {
            this.Name = name;
            this.Value = value;
        }

        public override string ToString()
        {
            return this.Name;
        }

    }

}
