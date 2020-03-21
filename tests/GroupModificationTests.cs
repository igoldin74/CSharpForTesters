using System;
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
                app.NavigationHelper.OpenGroupsPage();
            }
            var oldGroups = app.GroupHelper.GetGroups();
            int index = new Random().Next(oldGroups.Count);
            GroupData modifiedGroup = new GroupData("modified_group");
            modifiedGroup.Header = "modified_header";
            modifiedGroup.Footer = "modified_footer";
            app.GroupHelper.
                SelectGroupByIndex(index).
                InitGroupModification().
                FillOutGroupData(modifiedGroup).
                SubmitGroupModification();
            app.NavigationHelper.OpenGroupsPage();
            var newGroups = app.GroupHelper.GetGroups();
            oldGroups.RemoveAt(index);
            oldGroups.Add(modifiedGroup);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }
        
    }
}
