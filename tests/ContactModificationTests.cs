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
            app.NavigationHelper.ClickOnHomePageLink();
            app.ContactHelper.
                        InitRandomContactModification().
                        FillOutContactForm(modifiedContact).
                        SubmitContactModification();
        }
    }
}
