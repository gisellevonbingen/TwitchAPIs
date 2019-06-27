using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs
{
    public class EnumRegister<T, V> : List<T> where T : ValueEnum<V>
    {
        public EnumRegister()
        {

        }

        public T FromName(string name)
        {
            return this.FirstOrDefault(v => string.Equals(v.Name, name, StringComparison.OrdinalIgnoreCase));
        }

        public T FromValue(V value)
        {
            return this.FirstOrDefault(v => EqualityComparer<V>.Default.Equals(v.Value, value));
        }

    }

}
