using NUnit.Framework;


namespace addressbook_tests
{
    [TestFixture]
    public class CreateNewGroupTests : TestBase
    {


        [Test]
        public void CreateNewGroup()
        {
            navigationHelper.OpenHomePage();
            sessionHelper.Login(new AccountData("admin", "secret"));
            navigationHelper.OpenGroupsPage();
            groupHelper.InitGroupCreation();
            GroupData group = new GroupData("Group_Name_Super");
            group.Header = "Super_Header";
            group.Footer = "Super_Footer";
            groupHelper.FillOutGroupData(group);
            groupHelper.SubmitGroupCreation();
            navigationHelper.OpenGroupsPage();
            sessionHelper.Logout();
        }

    }
}

