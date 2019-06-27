using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs
{
    public class EnumRegister<T> : List<T> where T : ValueEnum
    {
        public EnumRegister()
        {

        }

        public T FromName(string name)
        {
            return this.FirstOrDefault(v => string.Equals(v.Name, name, StringComparison.OrdinalIgnoreCase));
        }

    }

}
