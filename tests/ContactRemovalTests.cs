using NUnit.Framework;
using System;

namespace addressbook_tests.tests
{
    [TestFixture]
    public class ContactRemovalTests : AuthTestBase
    {
        [Test]
        public void TestRemoveRandomContact()
        {
            var oldContacts = app.ContactHelper.GetContactsFromDB();
            int contactCount = oldContacts.Count;
            var contactToBeRemoved = oldContacts[0];

            if (contactCount == 0)
            {
                ContactData newContact = new ContactData("new_contact", "trrdfgfd");
                app.ContactHelper.
                       InitContactCreation().
                       FillOutContactForm(newContact).
                       SubmitNewContactForm();
                oldContacts = app.ContactHelper.GetContacts();
            }

            app.ContactHelper.DeleteContactById(contactToBeRemoved.Id);

            Assert.AreEqual(contactCount - 1, app.ContactHelper.GetContactCount());

            var newContacts = app.ContactHelper.GetContacts();
            oldContacts.RemoveAt(0);
            oldContacts.Sort();
            newContacts.Sort();

            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
