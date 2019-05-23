using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
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

            this.PrintAuthoriztion();
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

        public void PrintAuthoriztion()
        {
            this.PrintAuthoriztion(this.User, this.TwitchAPIHandler.OAuthAuthorization);
        }

        public void PrintUser(UserAbstract user, TwitchUser tuser)
        {
            user.SendMessage();
            user.SendMessage("== TwitchUser ==");
            user.SendMessage($"    BroadcasterType = {tuser.BroadcasterType}");
            user.SendMessage($"    Description = {tuser.Description}");
            user.SendMessage($"    DisplayName = {tuser.DisplayName}");
            user.SendMessage($"    Email = {tuser.Email}");
            user.SendMessage($"    Id = {tuser.Id}");
            user.SendMessage($"    Login = {tuser.Login}");
            user.SendMessage($"    OfflineImageUrl = {tuser.OfflineImageUrl}");
            user.SendMessage($"    ProfileImageUrl = {tuser.ProfileImageUrl}");
            user.SendMessage($"    Type = {tuser.Type}");
            user.SendMessage($"    ViewCount = {tuser.ViewCount}");
        }


        public void PrintAuthoriztion(UserAbstract user, OAuthAuthorization authorization)
        {
            user.SendMessage();
            user.SendMessage("== OAuthAuthorization ==");
            user.SendMessage($"    AccessToken = {authorization.AccessToken}");
            user.SendMessage($"    RefreshToken = {authorization.RefreshToken}");
            user.SendMessage($"    ExpiresIn = {authorization.ExpiresIn}");
            user.SendMessage($"    Scope = [{string.Join(", ", authorization.Scope ?? new string[0])}]");
            user.SendMessage($"    TokenType = {authorization.TokenType}");
        }

    }

}
