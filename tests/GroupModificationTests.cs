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
            var oldGroups = app.GroupHelper.GetGroups();
            int groupCount = oldGroups.Count;
            int index = new Random().Next(groupCount);

            if (groupCount == 0)
            {
                GroupData group = new GroupData("Group_Name_Super");
                group.Header = "test939e4";
                group.Footer = "dsjdfd";
                app.GroupHelper.Create(group);
                app.NavigationHelper.OpenGroupsPage();
                oldGroups = app.GroupHelper.GetGroups();
            }

            GroupData modifiedGroup = new GroupData("modified_group");
            modifiedGroup.Header = "modified_header";
            modifiedGroup.Footer = "modified_footer";
            GroupData groupToBeModified = oldGroups[index];

            app.GroupHelper.
                SelectGroupByIndex(index).
                InitGroupModification().
                FillOutGroupData(modifiedGroup).
                SubmitGroupModification();

            Assert.AreEqual(groupCount, app.GroupHelper.GetGroupCount());

            var newGroups = app.GroupHelper.GetGroups();
            oldGroups.RemoveAt(index);
            oldGroups.Add(modifiedGroup);
            oldGroups.Sort();
            newGroups.Sort();

            Assert.AreEqual(oldGroups, newGroups);

            //Extra assertion:
            foreach (GroupData group in newGroups)
            {
                if (group.Id == groupToBeModified.Id)
                {
                    Assert.AreEqual(group.Name, groupToBeModified.Name);
                }
            }
        }
        
    }
}
