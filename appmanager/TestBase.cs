using NUnit.Framework;

namespace addressbook_tests
{
    public class TestBase
    {
        protected ApplicationManager app;

        [SetUp]
        public void Setup()
        {
            app = new ApplicationManager();
            app.NavigationHelper.OpenHomePage();

        }

        [TearDown]
        public void Teardown()
        {
            app.Stop();
        }
    
    }
}
