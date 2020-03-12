using NUnit.Framework;

namespace addressbook_tests.tests
{
    [TestFixture]
    public class ContactRemovalTests : TestBase
    {
        [Test]
        public void TestRemoveRandomContact()
        {
            app.NavigationHelper.OpenLoginPage();
            app.SessionHelper.Login(new AccountData("admin", "secret"));
            app.NavigationHelper.ClickOnHomePageLink();
            app.ContactHelper.DeleteRandomContact();
        }
    }
}
