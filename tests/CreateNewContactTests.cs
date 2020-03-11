using NUnit.Framework;


namespace addressbook_tests
{
        [TestFixture]
        public class CreateNewContactTests : TestBase
        {
            [Test]
            public void CreateNewContactTest()
            {
                app.SessionHelper.Login(new AccountData("admin", "secret"));
                ContactData newContact = new ContactData("test_f_name", "test_l_name");
                app.ContactHelper.
                        InitContactCreation().
                        FillOutNewContactForm(newContact).
                        SubmitNewContactForm();
                app.NavigationHelper.ClickOnHomePageLink();
                app.SessionHelper.Logout();
             }

        }
}