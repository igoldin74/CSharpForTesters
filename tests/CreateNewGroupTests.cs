﻿using NUnit.Framework;
using System.Collections.Generic;
using System.IO;

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
                groups.Add(new GroupData(GenerateRandomString(10))
                {
                    Header = GenerateRandomString(20),
                    Footer = GenerateRandomString(20)
                });
            }
            return groups;
        }public static IEnumerable<GroupData> GroupDataFromFile()
        {
            List<GroupData> groups = new List<GroupData>();
            string[] lines = File.ReadAllLines(@"group.csv");
            foreach(string l in lines)
            {
                string[] parts = l.Split(',');
                groups.Add(new GroupData(parts[0])
                {
                    Header = parts[1],
                    Footer = parts[2]
                });
            }
            return groups;

        }

        [Test, TestCaseSource(nameof(GroupDataFromFile))]
        public void CreateNewGroup(GroupData group)
        {
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
