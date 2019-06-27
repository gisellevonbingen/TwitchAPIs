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

        public bool TryFromValue(V value, out T e)
        {
            foreach (var v in this)
            {
                if (EqualityComparer<V>.Default.Equals(v.Value, value) == true)
                {
                    e = v;
                    return true;
                }

            }

            e = default;
            return false;
        }

        public T FromValue(V value)
        {
            return this.TryFromValue(value, out var e) ? e : default;
        }

    }

}
