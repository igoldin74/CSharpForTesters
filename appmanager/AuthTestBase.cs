using NUnit.Framework;

namespace addressbook_tests
{
    public class AuthTestBase : TestBase
    {
        [SetUp]
        public void SetupLogin()
        {
            app.SessionHelper.Login(new AccountData("admin", "secret"));

        }
    }
}
