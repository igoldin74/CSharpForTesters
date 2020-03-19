using NUnit.Framework;

namespace addressbook_tests.tests
{
    [TestFixture]
    public class ContactRemovalTests : TestBase
    {
        [Test]
        public void TestRemoveRandomContact()
        {

            
            app.ContactHelper.DeleteRandomContact();
        }
    }
}
