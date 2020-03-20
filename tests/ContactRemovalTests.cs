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
            app.NavigationHelper.ClickOnHomePageLink();
            if (!app.ContactHelper.AreThereContacts())
            {
                ContactData newContact = new ContactData("new_contact", "trrdfgfd");
                app.ContactHelper.
                       InitContactCreation().
                       FillOutContactForm(newContact).
                       SubmitNewContactForm();
            }
            app.NavigationHelper.ClickOnHomePageLink();
            List<ContactData> oldContacts = app.ContactHelper.GetContacts();
            app.ContactHelper.DeleteContactByIndex(1);
            app.NavigationHelper.ClickOnHomePageLink();
            List<ContactData> newContacts = app.ContactHelper.GetContacts();
            oldContacts.RemoveAt(1);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
