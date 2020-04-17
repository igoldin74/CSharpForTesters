using Newtonsoft.Json;
using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using System.Xml;

namespace addressbook_tests
{
    [TestFixture]
    public class CreateNewContactTests : AuthTestBase
    {
        
        public static IEnumerable<ContactData> RandomContactDataProvider()
        {
            List<ContactData> contacts = new List<ContactData>();
            for (int i = 0; i < 2; i++)
            {
                contacts.Add(new ContactData(GenerateRandomString(6), GenerateRandomString(6))
                {
                    Address = GenerateRandomString(5),
                    MobilePhone = GenerateRandomString(5)
                });
            }
            return contacts;
        }

        public static IEnumerable<ContactData> ContactDataFromCsvFile()
        {
            List<ContactData> contacts = new List<ContactData>();
            string[] lines = File.ReadAllLines(Path.Combine(TestContext.CurrentContext.WorkDirectory, @"contacts.csv"));
            foreach (string l in lines)
            {
                string[] parts = l.Split(',');
                contacts.Add(new ContactData(parts[0], parts[1])
                {
                    Address = parts[2],
                    MobilePhone = parts[3],
                    Email1 = parts[4]
                });
            }
            return contacts;
        }

        public static IEnumerable<ContactData> ContactDataFromXmlFile()
        {
            return (List<ContactData>)new XmlSerializer(typeof(List<ContactData>))
                .Deserialize(new StreamReader(@"contacts.xml"));
        }

        public static IEnumerable<ContactData> ContactDataFromJsonFile()
        {
            return new List<ContactData>(JsonConvert.DeserializeObject<List<ContactData>>
                (File.ReadAllText(@"contacts.json")));
        }

        [Test, TestCaseSource("ContactDataFromXmlFile")]
        public void CreateNewContactTest(ContactData contact)
        {
            var oldContacts = app.ContactHelper.GetContactsFromDB();
            ContactData newContact = new ContactData("test_f_name", "test_l_name");

            app.ContactHelper.
                    InitContactCreation().
                    FillOutContactForm(contact).
                    SubmitNewContactForm();

            Assert.AreEqual(oldContacts.Count + 1, app.ContactHelper.GetContactCount());

            var newContacts = app.ContactHelper.GetContacts();
            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();

            Assert.AreEqual(oldContacts, newContacts);
        }

    }
}