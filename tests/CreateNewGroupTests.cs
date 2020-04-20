using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using System.Linq;
using Newtonsoft.Json;
using System;

namespace addressbook_tests
{
    [TestFixture]
    public class CreateNewGroupTests : GroupTestBase
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
        }
        
        public static IEnumerable<GroupData> GroupDataFromCsvFile()
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

        public static IEnumerable<GroupData> GroupDataFromXmlFile()
        {
            return (List<GroupData>) new XmlSerializer(typeof(List<GroupData>))
                .Deserialize(new StreamReader(@"groups.xml"));
        }

        public static IEnumerable<GroupData> GroupDataFromJsonFile()
        {
            return new List<GroupData>(JsonConvert.DeserializeObject<List<GroupData>>(File.ReadAllText(@"groups.json")));
        }

        [Test, TestCaseSource("GroupDataFromXmlFile")]
        public void CreateNewGroup(GroupData group)
        {
            var oldGroups = app.GroupHelper.GetGroupsFromDB();

            app.NavigationHelper.OpenGroupsPage();
            app.GroupHelper.Create(group);

            Assert.AreEqual(oldGroups.Count + 1, app.GroupHelper.GetGroupCount());

            oldGroups.Add(group);
            var newGroups = app.GroupHelper.GetGroupsFromDB();
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
        [Test]
        public void TestDBConnectivity()
        {
            var contacts = app.GroupHelper.GetContactsInGroup(app.GroupHelper.GetGroupsFromDB()[0].Id);
            foreach(ContactData c in contacts)
            {
                Console.WriteLine(c.FirstName);
            }
        }

    }
}
