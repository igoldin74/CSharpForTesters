using NUnit.Framework;

namespace addressbook_tests.tests
{
    [TestFixture]
    public class GroupModificationTests : TestBase
    {
        [Test]
        public void TestModifyRandomGroup()
        {
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
