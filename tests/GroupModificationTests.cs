using NUnit.Framework;

namespace addressbook_tests.tests
{
    [TestFixture]
    public class GroupModificationTests : AuthTestBase
    {
        [Test]
        public void TestModifyRandomGroup()
        {
            app.NavigationHelper.OpenGroupsPage();
            if (! app.GroupHelper.AreThereGroups())
            {
                GroupData group = new GroupData("Group_Name_Super");
                group.Header = "test939e4";
                group.Footer = "dsjdfd";
                app.GroupHelper.Create(group);
            }
            app.NavigationHelper.OpenGroupsPage();
            GroupData modifiedGroup = new GroupData("modified_group");
            modifiedGroup.Header = "modified_header";
            modifiedGroup.Footer = "modified_footer";
            app.GroupHelper.
                SelectRandomGroup().
                InitGroupModification().
                FillOutGroupData(modifiedGroup).
                SubmitGroupModification();
        }
        


    }
}
