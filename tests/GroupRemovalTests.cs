using System;
using NUnit.Framework;

namespace addressbook_tests.tests
{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase
    {
        [Test]
        public void TestRandomGroupRemoval()
        {
            var oldGroups = app.GroupHelper.GetGroups();
            int oldGroupsCount = oldGroups.Count;
            int index = new Random().Next(oldGroupsCount);

            if (oldGroupsCount == 0)
            {
                GroupData group = new GroupData("Group_Name_Super");
                group.Header = "test939e4";
                group.Footer = "dsjdfd";
                app.GroupHelper.Create(group);
                oldGroups = app.GroupHelper.GetGroups();
            }
            
            app.GroupHelper.
                SelectGroupByIndex(index).
                RemoveSelectedGroup();

            Assert.AreEqual(oldGroupsCount - 1, app.GroupHelper.GetGroupCount());

            var newGroups = app.GroupHelper.GetGroups();
            oldGroups.RemoveAt(index);
            oldGroups.Sort();
            newGroups.Sort();

            Assert.AreEqual(oldGroups, newGroups);
        }

    }
}
