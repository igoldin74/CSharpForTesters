using NUnit.Framework;
using System.Collections.Generic;


namespace addressbook_tests
{
    [TestFixture]
    public class CreateNewContactTests : AuthTestBase
    {
        
        public static IEnumerable<TestCaseData> RandomContactDataProvider()
        {
            for (int i = 0; i < 2; i++)
            {
                yield return new TestCaseData(new ContactData(GenerateRandomString(6), GenerateRandomString(6))
                {
                    Address = GenerateRandomString(5),
                    MobilePhone = GenerateRandomString(5)
                });
            }
        }

        [Test, TestCaseSource("RandomContactDataProvider")]
        public void CreateNewContactTest(ContactData contact)
        {
            var oldContacts = app.ContactHelper.GetContacts();
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