using NUnit.Framework;

namespace addressbook_tests.tests
{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase
    {
        [Test]
        public void TestRandomGroupRemoval()
        {
            app.NavigationHelper.OpenGroupsPage();
            app.GroupHelper.
                SelectRandomGroup().
                RemoveSelectedGroup();
        }

    }
}
