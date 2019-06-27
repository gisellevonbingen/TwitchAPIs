using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.New
{
    public class UserType : ValueEnum<string>
    {
        public static EnumRegister<UserType> Register { get; } = new EnumRegister<UserType>();

        public static UserType Staff { get; } = new UserType(nameof(Staff), "staff");
        public static UserType Admin { get; } = new UserType(nameof(Admin), "admin");
        public static UserType GlobalMod { get; } = new UserType(nameof(GlobalMod), "global_mod");
        public static UserType None { get; } = new UserType(nameof(None), "");

        private UserType(string name, string value) : base(name, value)
        {
            Register.Add(this);
        }

    }

}
