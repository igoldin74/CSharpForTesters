using NUnit.Framework;

namespace addressbook_tests.tests
{
    [TestFixture]
    public class GroupRemovalTests : TestBase
    {
        [Test]
        public void TestRandomGroupRemoval()
        {
            app.NavigationHelper.OpenLoginPage();
            app.SessionHelper.Login(new AccountData("admin", "secret"));
            app.NavigationHelper.OpenGroupsPage();
            app.GroupHelper.
                SelectRandomGroup().
                RemoveSelectedGroup();
            app.SessionHelper.Logout();
        }

    }
}
