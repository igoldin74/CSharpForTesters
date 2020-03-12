using NUnit.Framework;

namespace addressbook_tests.tests
{
    [TestFixture]
    public class ContactModificationTests : TestBase
    {
        [Test]
        public void TestModifyContact()
        {
            ContactData modifiedContact = new ContactData("trrragdh", "abracadabra");
            app.NavigationHelper.OpenLoginPage();
            app.SessionHelper.Login(new AccountData("admin", "secret"));
            app.NavigationHelper.ClickOnHomePageLink();
            app.ContactHelper.
                        InitRandomContactModification().
                        FillOutContactForm(modifiedContact).
                        SubmitContactModification();
            app.SessionHelper.Logout();
        }
    }
}
