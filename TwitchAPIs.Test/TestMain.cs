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

            user.SendMessageAsReflection("Current OAuthAuthorization", handler.AuthenticationResult);
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
            var testMap = this.GetTestMap();

            user.SendMessage();
            user.SendMessage();
            user.SendMessage($"Return to '{user.ReturnInput}'");

            while (true)
            {
                try
                {
                    user.SendMessage();

                    var versions = testMap.OrderBy(pair => pair.Key);
                    var versionInput = user.QueryInput("Enter Version", versions, pair => pair.Key);

                    var resources = versionInput.Value.Value.OrderBy(pair => pair.Key);
                    var reosurceInput = user.QueryInput("Enter Resource", resources, pair => pair.Key);

                    var tests = reosurceInput.Value.Value.OrderBy(t => t.GetType().FullName);
                    var testInput = user.QueryInput("Enter Test", tests, t => t.GetType().Name);

                    var test = testInput.Value;
                    user.SendMessage("Test - " + test.GetType().Name);

                    test.Run(this);

                    user.SendMessage();
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

        private Dictionary<string, Dictionary<string, List<TestAbstract>>> GetTestMap()
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

    }

}
