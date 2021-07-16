using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Giselle.Commons.Collections;
using Giselle.Commons.Tags;

namespace TwitchAPIs.New
{
    public class UserRequestType : SimpleNameTag
    {
        public static SimpleNameTags<UserRequestType> Tags { get; } = new SimpleNameTags<UserRequestType>();

        public static UserRequestType Id { get; } = Tags.AddAndGet(new UserRequestType("id"));
        public static UserRequestType Login { get; } = Tags.AddAndGet(new UserRequestType("login"));

        public UserRequestType(string name) : base(name)
        {

        }

    }

}
