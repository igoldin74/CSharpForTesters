using NUnit.Framework;
using System;

namespace addressbook_tests.tests
{
    [TestFixture]
    public class GroupModificationTests : AuthTestBase
    {
        [Test]
        public void TestModifyRandomGroup()
        {
            app.NavigationHelper.OpenGroupsPage();
            var oldGroups = app.GroupHelper.GetGroupsFromDB();
            int groupCount = oldGroups.Count;
            //int index = new Random().Next(groupCount);

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
            GroupData groupToBeModified = oldGroups[0];

            app.GroupHelper.
                SelectGroupById(groupToBeModified.Id).
                InitGroupModification().
                FillOutGroupData(modifiedGroup).
                SubmitGroupModification();

            Assert.AreEqual(groupCount, app.GroupHelper.GetGroupCount());

            var newGroups = app.GroupHelper.GetGroupsFromDB();
            oldGroups.RemoveAt(0);
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
