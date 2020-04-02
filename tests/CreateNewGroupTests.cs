using System;
using System.Collections.Generic;
using NUnit.Framework;


namespace addressbook_tests
{
    [TestFixture]
    public class CreateNewGroupTests : AuthTestBase
    {

        public static IEnumerable<GroupData> RandomGroupDataProvider()
        {
            List<GroupData> groups = new List<GroupData>();
            for (int i = 0; i < 5; i++)
            {
                groups.Add(new GroupData(GenerateRandomString(30))
                {
                    Header = GenerateRandomString(100),
                    Footer = GenerateRandomString(100)
                });
            }
            return groups;
        }



        [Test, TestCaseSource("RandomGroupDataProvider")]
        public void CreateNewGroup(GroupData group)
        {
            group.Header = "test939e4";
            group.Footer = "dsjdfd";

            var oldGroups = app.GroupHelper.GetGroups();

            app.GroupHelper.Create(group);

            Assert.AreEqual(oldGroups.Count + 1, app.GroupHelper.GetGroupCount());

            oldGroups.Add(group);
            var newGroups = app.GroupHelper.GetGroups();
            oldGroups.Sort();
            newGroups.Sort();

            Assert.AreEqual(oldGroups, newGroups);

            foreach (GroupData g in newGroups)
            {
                if (g.Name == group.Name)
                {
                    Assert.Pass("Name of the new group exists in the group list");
                }
            }
        }

    }
}

