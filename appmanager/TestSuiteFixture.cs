using System;
using NUnit.Framework;

namespace addressbook_tests
{
    // [SetUpFixture] = Operation before each test suite:
    [SetUpFixture]
    public class TestSuiteFixture
    {
        // Global (static) variable ApplicationManager:
        public static ApplicationManager app;

        [OneTimeSetUp]
        public void InitAppManager()
        {
            app = new ApplicationManager();
            app.SessionHelper.Login(new AccountData("admin", "secret"));
        }

        [OneTimeTearDown]
        public void StopAppManager()
        {
            app.SessionHelper.Logout();
            app.Stop();

        }
    }
}
