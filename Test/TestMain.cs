using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace TwitchAPI.Test
{
    public class TestMain
    {
        [STAThread]
        public static void Main(string[] args)
        {
            new TestMain(args);
        }

        public UserAbstract User { get; private set; }

        public TwitchAPIHandler TwitchAPIHandler { get; private set; }

        public TestMain(string[] args)
        {
            Application.SetCompatibleTextRenderingDefault(false);
            Application.EnableVisualStyles();

            var user = this.User = new UserConsole();
            var handlerUser = this.CreateHanlderUser(args, user);
            var handler = this.TwitchAPIHandler = new TwitchAPIHandler(handlerUser);

            if (handler.Create() == false)
            {
                user.SendMessage($"What's wrong?");
                return;
            }

            this.PrintReflection(user, "Current OAuthAuthorization", handler.OAuthAuthorization);
            this.RunTest();
        }

        private UserAbstract CreateHanlderUser(string[] args, UserAbstract fallback)
        {
            if (args.Length > 0)
            {
                return new UserFile(args[0]);
            }
            else
            {
                return fallback;
            }

        }

        private void RunTest()
        {
            var user = this.User;

            var tests = new List<TestAbstract>();
            tests.Add(new TestGetUser());
            tests.Add(new TestUpdateUser());
            tests.Add(new TestGetUserFollows());
            tests.Add(new TestRefreshOAuthAuthorization());
            tests.Add(new TestSearch());

            while (true)
            {
                user.SendMessage();
                user.SendMessage();

                var input = user.QueryInput("Enter Test number", tests.Select(t => t.GetType().Name).ToArray(), true);

                if (input != -1)
                {
                    var test = tests[input];
                    user.SendMessage("Test - " + test.GetType().Name);
                    test.Run(this);
                }
                else
                {
                    break;
                }

            }

        }

        public void PrintReflection<T>(UserAbstract user, string name, T value)
        {
            user.SendMessage();
            user.SendMessage($"== {name} ==");
            user.SendMessage($"    Is Null = {value == null}");

            if (value != null)
            {
                var type = value.GetType();
                user.SendMessage($"    Type.FullName = {type.FullName}");
                var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.GetProperty);
                user.SendMessage($"    Properties.Length = {properties.Length}");

                for (int i = 0; i < properties.Length; i++)
                {
                    var property = properties[i];
                    user.SendMessage($"    {property.Name} = {this.ToString(property.GetValue(value))}");
                }

            }

        }

        public object ToString(object obj)
        {
            if (obj == null)
            {
                return "{null}";
            }
            else if (obj is Array arry)
            {
                return $"[{string.Join(", ", (object[]) arry)}]";
            }
            else
            {
                var toString = obj.ToString();
                return $"'{toString}'";
            }

        }

    }

}
