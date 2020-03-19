using NUnit.Framework;

namespace addressbook_tests.tests
{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase
    {
        [Test]
        public void TestRandomGroupRemoval()
        {
            app.NavigationHelper.OpenGroupsPage();
            if (!app.GroupHelper.AreThereGroups())
            {
                GroupData group = new GroupData("Group_Name_Super");
                group.Header = "test939e4";
                group.Footer = "dsjdfd";
                app.GroupHelper.Create(group);
            }
            app.NavigationHelper.OpenGroupsPage();
            app.GroupHelper.
                SelectRandomGroup().
                RemoveSelectedGroup();
        }

    }
}
