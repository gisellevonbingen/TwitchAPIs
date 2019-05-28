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

namespace TwitchAPIs.Test
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
            tests.Add(new TestGetChannel());
            tests.Add(new TestGetTopGames());

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
            var lines = this.ToString(value);

            user.SendMessage();
            user.SendMessage($"== {name} ==");

            for (int i = 0; i < lines.Count; i++)
            {
                var line = lines[i];
                var prefix = new string(' ', (line.Level + 1) * 4);
                user.SendMessage($"{prefix}{line.Message}");
            }

        }

        public List<PrintableLine> ToString(object obj, int level = 0)
        {
            var list = new List<PrintableLine>();

            if (obj == null)
            {
                list.Add(new PrintableLine(level, "{null}"));
            }
            else if (obj is IConvertible convertible)
            {
                list.Add(new PrintableLine(level, $"'{convertible}'"));
            }
            else if (obj is IEnumerable enumerable)
            {
                var array = enumerable.OfType<object>().ToArray();
                list.Add(new PrintableLine(level, $"Enumerable Count = {array.Length}"));

                for (int i = 0; i < array.Length; i++)
                {
                    list.Add(new PrintableLine(level, $"{i}/{array.Length}"));
                    list.AddRange(ToString(array[i], level + 1));
                }

            }
            else
            {
                var type = obj.GetType();
                var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.GetProperty);

                list.Add(new PrintableLine(level, $"Type.FullName = {type.FullName}"));
                list.Add(new PrintableLine(level, $"Properties.Length = {properties.Length}"));

                for (int i = 0; i < properties.Length; i++)
                {
                    var property = properties[i];
                    var propertyLines = this.ToString(property.GetValue(obj), level + 1);

                    if (propertyLines.Count == 1)
                    {
                        list.Add(new PrintableLine(level, $"{property.Name} = {propertyLines[0].Message}"));
                    }
                    else
                    {
                        list.Add(new PrintableLine(level, $"{property.Name}"));
                        list.AddRange(propertyLines);
                    }

                }

            }

            return list;
        }

    }

}
