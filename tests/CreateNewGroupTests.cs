using NUnit.Framework;


namespace addressbook_tests
{
    [TestFixture]
    public class CreateNewGroupTests : TestBase
    {


        [Test]
        public void CreateNewGroup()
        {
            app.NavigationHelper.OpenHomePage();
            app.SessionHelper.Login(new AccountData("admin", "secret"));
            GroupData group = new GroupData("Group_Name_Super");
            group.Header = "test939e4";
            group.Footer = "dsjdfd";
            app.GroupHelper.Create(group);
            app.NavigationHelper.OpenGroupsPage();
            app.SessionHelper.Logout();
        }

    }
}

