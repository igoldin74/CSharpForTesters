using NUnit.Framework;


namespace addressbook_tests
{
        [TestFixture]
        public class CreateNewContactTests : TestBase
        {
            

            [Test]
            public void CreateNewContactTest()
            {
                navigationHelper.OpenHomePage();
                sessionHelper.Login(new AccountData("admin", "secret"));
                contactHelper.InitContactCreation();
                ContactData newContact = new ContactData("test_f_name", "test_l_name");
                contactHelper.FillOutNewContactForm(newContact);
                contactHelper.SubmitNewContactForm();
                navigationHelper.ClickOnHomePageLink();
                sessionHelper.Logout();
             }

        }
}