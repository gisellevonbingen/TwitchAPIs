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
using Giselle.Commons.Users;

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
            var mainStep = this.GetTestStep();

            user.SendMessage();
            user.SendMessage();
            user.SendMessage($"Return to '{user.ReturnInput}'");

            while (true)
            {
                try
                {
                    user.SendMessage();

                    var parentStep = mainStep;

                    while (true)
                    {
                        var list = new List<KeyValuePair<string, object>>();
                        list.AddRange(parentStep.Children.Select(s => new KeyValuePair<string, object>(s.Name, s)));
                        list.AddRange(parentStep.Tests.Select(t => new KeyValuePair<string, object>(t.GetType().Name, t)));

                        var selected = user.QueryInput("Enter Step, Test", list, pair => pair.Key).Value.Value;

                        if (selected is TestStep step)
                        {
                            parentStep = step;
                        }
                        else if (selected is TestAbstract test)
                        {
                            test.Run(this);
                            break;
                        }

                    }

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
        private TestStep GetStep(TestStep mainStep, string[] stepNames)
        {
            var parent = mainStep;

            foreach (var stepName in stepNames)
            {
                parent = this.GetStep(parent, stepName);
            }

            return parent;
        }

        private TestStep GetStep(TestStep parent, string stepName)
        {
            var step = parent.Children.FirstOrDefault(s => s.Name.Equals(stepName, StringComparison.OrdinalIgnoreCase));

            if (step != null)
            {
                return step;
            }
            else
            {
                step = new TestStep(stepName);
                parent.Children.Add(step);

                return step;
            }

        }

        private TestStep GetTestStep()
        {
            var mainStep = new TestStep("TwitchAPIs.Test");

            var testType = typeof(TestAbstract);
            var types = this.GetType().Assembly.GetTypes();

            foreach (var type in types)
            {
                if (testType.IsAssignableFrom(type) == true && type.Equals(testType) == false)
                {
                    var testAttribute = type.GetCustomAttribute<TwitchAPITestAttribute>();
                    var steps = testAttribute?.Steps;

                    if (steps != null)
                    {
                        var step = this.GetStep(mainStep, steps);
                        var testObject = type.GetConstructor(new Type[0]).Invoke(new object[0]) as TestAbstract;

                        step.Tests.Add(testObject);
                    }
                    else
                    {
                        throw new TwitchException($"{type.FullName} not have {nameof(TwitchAPITestAttribute)}");
                    }

                }

            }

            return mainStep;
        }

    }

}
