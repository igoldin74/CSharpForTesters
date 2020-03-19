using NUnit.Framework;

namespace addressbook_tests.tests
{
    [TestFixture]
    public class LoginTests : TestBase
    {
        [Test]
        public void LoginWithValidCreds()
        {
            app.SessionHelper.Logout();
            AccountData account = new AccountData("admin", "secret");
            app.SessionHelper.Login(account);
            Assert.IsTrue(app.SessionHelper.IsLoggedIn(account));
        }

        [Test]
        public void LoginWithInvalidCreds()
        {
            app.SessionHelper.Logout();
            AccountData account = new AccountData("admin", "bad");
            app.SessionHelper.Login(account);
            Assert.IsFalse(app.SessionHelper.IsLoggedIn(account));
        }
    }
}
