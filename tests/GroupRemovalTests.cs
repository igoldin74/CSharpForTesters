using NUnit.Framework;
using System;

namespace addressbook_tests.tests
{
    [TestFixture]
    public class GroupRemovalTests : GroupTestBase
    {
        [Test]
        public void TestGroupRemoval()
        {
            var oldGroups = app.GroupHelper.GetGroupsFromDB();
            int oldGroupsCount = oldGroups.Count;
            var toBeRemoved = oldGroups[0];

            if (oldGroupsCount == 0)
            {
                GroupData group = new GroupData("Group_Name_Super");
                group.Header = "test939e4";
                group.Footer = "dsjdfd";
                app.GroupHelper.Create(group);
                oldGroups = app.GroupHelper.GetGroups();
            }
            app.NavigationHelper.OpenGroupsPage();
            app.GroupHelper.
                SelectGroupById(toBeRemoved.Id).
                RemoveSelectedGroup();

            Assert.AreEqual(oldGroupsCount - 1, app.GroupHelper.GetGroupCount());

            var newGroups = app.GroupHelper.GetGroupsFromDB();
            oldGroups.RemoveAt(0);
            oldGroups.Sort();
            newGroups.Sort();

            Assert.AreEqual(oldGroups, newGroups);

            foreach (GroupData group in newGroups)
            {
                Assert.AreNotEqual(group.Id, toBeRemoved.Id);
            }
        }

    }
}
