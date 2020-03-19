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
            app.ContactHelper
                .InitRandomContactModification()
                .FillOutContactForm(modifiedContact)
                .SubmitContactModification();

        }
    }
}
