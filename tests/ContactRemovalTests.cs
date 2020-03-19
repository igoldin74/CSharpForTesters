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
            app.ContactHelper.DeleteRandomContact();
        }
    }
}
