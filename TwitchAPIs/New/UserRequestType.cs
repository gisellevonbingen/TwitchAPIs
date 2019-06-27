using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.New
{
    public class UserRequestType : ValueEnum<string>
    {
        public static EnumRegister<UserRequestType, string> Register { get; } = new EnumRegister<UserRequestType, string>();

        public static UserRequestType Id { get; } = new UserRequestType(nameof(Id), "id");
        public static UserRequestType Login { get; } = new UserRequestType(nameof(Login), "login");

        private UserRequestType(string name, string value) : base(name, value)
        {
            Register.Add(this);
        }

    }

}
