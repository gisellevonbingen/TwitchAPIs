using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.V5
{
    public class UserType : ValueEnum<string>
    {
        public static EnumRegister<UserType, string> Register { get; } = new EnumRegister<UserType, string>((o, n, v) => new UserType(o, n, v));

        public static UserType Staff { get; } = Register.Generate(nameof(Staff), "staff");
        public static UserType Admin { get; } = Register.Generate(nameof(Admin), "admin");
        public static UserType GlobalMod { get; } = Register.Generate(nameof(GlobalMod), "global_mod");
        public static UserType User { get; } = Register.Generate(nameof(User), "user");

        private UserType(int ordinal, string name, string value) : base(ordinal, name, value)
        {

        }

    }

}
