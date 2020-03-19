using NUnit.Framework;

namespace addressbook_tests.tests
{
    [TestFixture]
    public class ContactRemovalTests : AuthTestBase
    {
        [Test]
        public void TestRemoveRandomContact()
        {

            
            app.ContactHelper.DeleteRandomContact();
        }
    }
}
