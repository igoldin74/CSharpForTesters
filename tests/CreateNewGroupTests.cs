using NUnit.Framework;


namespace addressbook_tests
{
    [TestFixture]
    public class CreateNewGroupTests : AuthTestBase
    {


        [Test]
        public void CreateNewGroup()
        {
            GroupData group = new GroupData("Group_Name_Super");
            group.Header = "test939e4";
            group.Footer = "dsjdfd";

            var oldGroups = app.GroupHelper.GetGroups();

            app.GroupHelper.Create(group);

            Assert.AreEqual(oldGroups.Count + 1, app.GroupHelper.GetGroupCount());

            oldGroups.Add(group);
            var newGroups = app.GroupHelper.GetGroups();
            oldGroups.Sort();
            newGroups.Sort();

            Assert.AreEqual(oldGroups, newGroups);
        }

    }
}

