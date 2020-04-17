using NUnit.Framework;
using System;

namespace addressbook_tests.tests
{
    [TestFixture]
    public class ContactModificationTests : AuthTestBase
    {
        [Test]
        public void TestModifyContact()
        {
            var oldContacts = app.ContactHelper.GetContactsFromDB();
            var contactToBeModified = oldContacts[0];
            int contactCount = oldContacts.Count;
            //int index = new Random().Next(contactCount);

            if (contactCount == 0)
            {
                ContactData newContact = new ContactData("new_contact", "trrdfgfd");
                app.ContactHelper.
                       InitContactCreation().
                       FillOutContactForm(newContact).
                       SubmitNewContactForm();
                oldContacts = app.ContactHelper.GetContacts();
            }

            ContactData modifiedContact = new ContactData("trrragdh", "abracadabra");
            app.ContactHelper
                .InitContactModificationById(contactToBeModified.Id)
                .FillOutContactForm(modifiedContact)
                .SubmitContactModification();

            Assert.AreEqual(contactCount, app.ContactHelper.GetContactCount());

            var newContacts = app.ContactHelper.GetContacts();
            oldContacts.RemoveAt(0);
            oldContacts.Add(modifiedContact);
            oldContacts.Sort();
            newContacts.Sort();

            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
