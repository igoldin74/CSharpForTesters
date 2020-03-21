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
            app.NavigationHelper.OpenGroupsPage();
            if (!app.GroupHelper.AreThereGroups())
            {
                GroupData group = new GroupData("Group_Name_Super");
                group.Header = "test939e4";
                group.Footer = "dsjdfd";
                app.GroupHelper.Create(group);
            }
            app.NavigationHelper.OpenGroupsPage();
            var oldGroups = app.GroupHelper.GetGroups();
            int index = new Random().Next(oldGroups.Count);
            app.GroupHelper.
                SelectGroupByIndex(index).
                RemoveSelectedGroup();
            app.NavigationHelper.OpenGroupsPage();
            var newGroups = app.GroupHelper.GetGroups();
            oldGroups.RemoveAt(index);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }

    }
}
