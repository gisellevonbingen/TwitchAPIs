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

        private void AddTestCase(Dictionary<string, List<TestAbstract>> tests, string category, TestAbstract test)
        {
            if (tests.TryGetValue(category, out var list) == false)
            {
                list = new List<TestAbstract>();
                tests[category] = list;
            }

            list.Add(test);
        }

        private void RunTest()
        {
            var user = this.User;

            var testMap = new Dictionary<string, List<TestAbstract>>();
            this.AddTestCase(testMap, "Authorization", new TestRefreshOAuthAuthorization());

            this.AddTestCase(testMap, "User", new TestGetUser());
            this.AddTestCase(testMap, "User", new TestUpdateUser());
            this.AddTestCase(testMap, "User", new TestGetUserFollowsNew());
            this.AddTestCase(testMap, "User", new TestGetUserFollowsV5());
            this.AddTestCase(testMap, "User", new TestUserFollow());
            this.AddTestCase(testMap, "User", new TestUserUnfollow());
            this.AddTestCase(testMap, "User", new TestGetUserEmotes());

            this.AddTestCase(testMap, "Search", new TestSearchChannels());
            this.AddTestCase(testMap, "Search", new TestSearchGames());

            this.AddTestCase(testMap, "Game", new TestGetTopGames());
            this.AddTestCase(testMap, "Game", new TestGetGames());

            this.AddTestCase(testMap, "Chat", new TestGetChatBadges());
            this.AddTestCase(testMap, "Chat", new TestGetChatRooms());

            this.AddTestCase(testMap, "Channel", new TestGetChannel());
            this.AddTestCase(testMap, "Clip", new TestGetClips());
            this.AddTestCase(testMap, "Tag", new TestGetAllStreamTags());
            this.AddTestCase(testMap, "Bit", new TestGetCheermotes());

            while (true)
            {
                user.SendMessage();
                user.SendMessage();

                var categories = testMap.Select(pair => pair.Key).ToArray();
                var categoryIndex = user.QueryInput("Enter Category", categories, true);

                if (categoryIndex == -1)
                {
                    break;
                }

                var testList = testMap[categories[categoryIndex]];
                var testIndex = user.QueryInput("Enter Test", testList.Select(t => t.GetType().Name), true);

                if (testIndex == -1)
                {
                    continue;
                }

                var test = testList[testIndex];
                user.SendMessage("Test - " + test.GetType().Name);

                test.Run(this);
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
