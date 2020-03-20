using System;
using NUnit.Framework;

namespace addressbook_tests.tests
{
    [TestFixture]
    public class ContactModificationTests : AuthTestBase
    {
        [Test]
        public void TestModifyContact()
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
            ContactData modifiedContact = new ContactData("trrragdh", "abracadabra");
            app.NavigationHelper.ClickOnHomePageLink();
            var oldContacts = app.ContactHelper.GetContacts();
            int index = new Random().Next(oldContacts.Count);
            app.ContactHelper
                .InitContactModificationByIndex(index)
                .FillOutContactForm(modifiedContact)
                .SubmitContactModification();
            app.NavigationHelper.ClickOnHomePageLink();
            oldContacts.RemoveAt(index);
            oldContacts.Add(modifiedContact);
            oldContacts.Sort();
            var newContacts = app.ContactHelper.GetContacts();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
