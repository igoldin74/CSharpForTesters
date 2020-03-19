using NUnit.Framework;

namespace addressbook_tests
{
    public class TestBase
    {
        protected ApplicationManager app;

        // [SetUp] = Operation before each test:
        [SetUp]
        public void SetupAppManager()
        {
            app = ApplicationManager.GetInstance();
        }

    }
}
