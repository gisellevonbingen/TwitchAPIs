using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.New
{
    public struct UserRequest : IEquatable<UserRequest>
    {
        public UserType Type { get; set; }

        public string Value { get; set; }

        public UserRequest(UserType type, string value) : this()
        {
            this.Type = type;
            this.Value = value;
        }

        public override bool Equals(object obj)
        {
            return obj is UserRequest other ? this.Equals(other) : false;
        }

        public bool Equals(UserRequest other)
        {
            if (other.GetType() != this.GetType())
            {
                return false;
            }

            if (this.Type != other.Type)
            {
                return false;
            }

            if (string.Equals(this.Value, other.Value, StringComparison.OrdinalIgnoreCase) == false)
            {
                return false;
            }

            return true;
        }

        public override string ToString()
        {
            var type = this.Type.ToString().ToLowerInvariant();
            var value = this.Value;
            return $"{type}={value}";
        }

        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }

    }

}
