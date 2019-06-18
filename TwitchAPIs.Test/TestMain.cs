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
            var testMap = this.NewMethod();

            while (true)
            {
                try
                {
                    user.SendMessage();
                    user.SendMessage();

                    var versions = testMap.OrderBy(pair => pair.Key).ToArray();
                    var versionIndex = user.QueryInput("Enter Version", versions.Select(pair => pair.Key), true);

                    if (versionIndex == -1)
                    {
                        break;
                    }

                    var reources = versions[versionIndex].Value.OrderBy(pair => pair.Key).ToArray();
                    var reosurceIndex = user.QueryInput("Enter Resource", reources.Select(pair => pair.Key), true);

                    if (reosurceIndex == -1)
                    {
                        continue;
                    }

                    var tests = reources[reosurceIndex].Value.ToArray();
                    var testsIndex = user.QueryInput("Enter Resource", tests.Select(t => t.GetType().Name), true);

                    if (testsIndex == -1)
                    {
                        continue;
                    }

                    var test = tests[testsIndex];
                    user.SendMessage("Test - " + test.GetType().Name);

                    test.Run(this);
                }
                catch (UserInputReturnException)
                {
                    user.SendMessage("Returned");
                }
                catch (Exception e)
                {
                    user.SendMessage("===== Exception Start =====");
                    user.SendMessage(e.ToString());
                    user.SendMessage("===== Exception End =====");
                }

            }

        }

        private Dictionary<string, Dictionary<string, List<TestAbstract>>> NewMethod()
        {
            var testMap = new Dictionary<string, Dictionary<string, List<TestAbstract>>>();

            var testType = typeof(TestAbstract);
            var types = this.GetType().Assembly.GetTypes();

            foreach (var type in types)
            {
                if (testType.IsAssignableFrom(type) == true && type.Equals(testType) == false)
                {
                    var testAttribute = type.GetCustomAttribute<TwitchAPITestAttribute>();

                    if (testAttribute != null)
                    {
                        var testObject = type.GetConstructor(new Type[0]).Invoke(new object[0]) as TestAbstract;
                        this.AddTestCase(testMap, testAttribute.Version, testAttribute.Resource, testObject);
                    }
                    else
                    {
                        throw new TwitchException($"{type.FullName} not have {nameof(TwitchAPITestAttribute)}");
                    }

                }

            }

            return testMap;
        }

        private void AddTestCase(Dictionary<string, Dictionary<string, List<TestAbstract>>> tests, string version, string resrouce, TestAbstract test)
        {
            if (tests.TryGetValue(version, out var versionMap) == false)
            {
                versionMap = new Dictionary<string, List<TestAbstract>>();
                tests[version] = versionMap;
            }

            if (versionMap.TryGetValue(resrouce, out var resourceList) == false)
            {
                resourceList = new List<TestAbstract>();
                versionMap[resrouce] = resourceList;
            }

            resourceList.Add(test);
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
