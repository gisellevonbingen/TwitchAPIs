using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Giselle.Commons.Collections;
using Giselle.Commons.Tags;

namespace TwitchAPIs.V5
{
    public class UserType : SimpleNameTag
    {
        public static SimpleNameTags<UserType> Tags { get; } = new SimpleNameTags<UserType>();

        public static UserType Staff { get; } = Tags.AddAndGet(new UserType("staff"));
        public static UserType Admin { get; } = Tags.AddAndGet(new UserType("admin"));
        public static UserType GlobalMod { get; } = Tags.AddAndGet(new UserType("global_mod"));
        public static UserType User { get; } = Tags.AddAndGet(new UserType("user"));

        public UserType(string name) : base(name)
        {
        }

    }

}
