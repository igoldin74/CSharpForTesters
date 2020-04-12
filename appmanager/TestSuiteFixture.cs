using NUnit.Framework;

namespace addressbook_tests
{
    // [SetUpFixture] = Operation before each test suit - to be removed when Selenium destructor bug will get addressed.
    [SetUpFixture]
    public class TestSuiteFixture
    {
        // Used in place of destructor until further notice.
        [TearDown]
        public void StopAppManager()
        {
            ApplicationManager.GetInstance().SessionHelper.Logout();
            ApplicationManager.GetInstance().Stop();

        }
    }
}
