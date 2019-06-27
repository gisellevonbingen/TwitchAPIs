using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.New
{
    public class UserRequestType : ValueEnum<string>
    {
        public static EnumRegister<UserRequestType, string> Register { get; } = new EnumRegister<UserRequestType, string>((o, n, v) => new UserRequestType(o, n, v));

        public static UserRequestType Id { get; } = Register.Generate(nameof(Id), "id");
        public static UserRequestType Login { get; } = Register.Generate(nameof(Login), "login");

        private UserRequestType(int ordinal, string name, string value) : base(ordinal, name, value)
        {

        }

    }

}
