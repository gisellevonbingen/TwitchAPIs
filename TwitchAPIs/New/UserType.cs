using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.New
{
    public class UserType : ValueEnum<string>
    {
        public static EnumRegister<UserType, string> Register { get; } = new EnumRegister<UserType, string>();

        public static UserType Id { get; } = new UserType(nameof(Id), "id");
        public static UserType Login { get; } = new UserType(nameof(Login), "login");

        private UserType(string name, string value) : base(name, value)
        {
            Register.Add(this);
        }

    }

}
