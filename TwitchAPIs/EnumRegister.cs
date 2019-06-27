using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs
{
    public class EnumRegister<T, P> : IEnumerable<T>, IReadOnlyList<T> where T : ValueEnum
    {
        private List<T> List { get; }
        private Func<int, string, P, T> Generater { get; }

        public int Count => this.List.Count;

        public T this[int index] => this.List[index];

        public EnumRegister(Func<int, string, P, T> generater)
        {
            this.List = new List<T>();
            this.Generater = generater;
        }

        public T Generate(string name, P parameter)
        {
            lock (this.List)
            {
                if (this.FromName(name) != null)
                {
                    throw new ArgumentException($"Already generated name : {name}");
                }

                var ordinal = this.List.Count;
                var value = this.Generater(ordinal, name, parameter);
                this.List.Add(value);

                return value;
            }

        }

        public T FromName(string name)
        {
            return this.FirstOrDefault(v => string.Equals(v.Name, name, StringComparison.OrdinalIgnoreCase));
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this.List.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

    }

}
