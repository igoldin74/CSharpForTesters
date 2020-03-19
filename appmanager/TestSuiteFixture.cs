using System;
using NUnit.Framework;

namespace addressbook_tests
{
    // [SetUpFixture] = Operation before each test suite:
    [SetUpFixture]
    public class TestSuiteFixture
    {
        // Global (static) variable ApplicationManager:
        // public static ApplicationManager app;

        [OneTimeSetUp]
        public void InitAppManager()
        {
            ApplicationManager app = ApplicationManager.GetInstance();
            app.SessionHelper.Login(new AccountData("admin", "secret"));
        }

        [OneTimeTearDown]
        public void StopAppManager()
        {
            ApplicationManager.GetInstance().SessionHelper.Logout();
            ApplicationManager.GetInstance().Stop();

        }
    }
}
