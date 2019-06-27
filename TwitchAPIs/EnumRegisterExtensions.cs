using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs
{
    public static class EnumRegisterExtensions
    {
        public static bool TryFromValue<T, B, E>(this EnumRegister<T, B> register, E value, out T e) where T : ValueEnum<E>
        {
            foreach (var v in register)
            {
                if (EqualityComparer<E>.Default.Equals(v.Value, value) == true)
                {
                    e = v;
                    return true;
                }

            }

            e = default;
            return false;
        }

        public static T FromValue<T, B, E>(this EnumRegister<T, B> register, E value) where T : ValueEnum<E>
        {
            return TryFromValue(register, value, out var e) ? e : default;
        }

    }

}
