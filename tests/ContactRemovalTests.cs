using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace addressbook_tests.tests
{
    [TestFixture]
    public class ContactRemovalTests : AuthTestBase
    {
        [Test]
        public void TestRemoveRandomContact()
        {
            var oldContacts = app.ContactHelper.GetContacts();
            int contactCount = oldContacts.Count;
            int index = new Random().Next(contactCount);

            if (contactCount == 0)
            {
                ContactData newContact = new ContactData("new_contact", "trrdfgfd");
                app.ContactHelper.
                       InitContactCreation().
                       FillOutContactForm(newContact).
                       SubmitNewContactForm();
                oldContacts = app.ContactHelper.GetContacts();
            }

            app.ContactHelper.DeleteContactByIndex(index);

            Assert.AreEqual(contactCount - 1, app.ContactHelper.GetContactCount());

            var newContacts = app.ContactHelper.GetContacts();
            oldContacts.RemoveAt(index);
            oldContacts.Sort();
            newContacts.Sort();

            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
