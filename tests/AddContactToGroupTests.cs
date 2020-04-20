using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook_tests
{
    class AddContactToGroupTests : AuthTestBase
    {
        [Test]
        public void TestAddingContactToGroup()
        {
            GroupData group = app.GroupHelper.GetGroupsFromDB()[0];
            var oldContactList = app.GroupHelper.GetContactsInGroup(group.Id);
            ContactData contact = app.ContactHelper.GetContactsFromDB()
                .Except(oldContactList).First();

            app.ContactHelper.AddContactToGroup(contact, group);

            var newContactList = app.GroupHelper.GetContactsInGroup(group.Id);
            oldContactList.Add(contact);
            newContactList.Sort();
            oldContactList.Sort();
            Console.WriteLine(newContactList.ToString());
            Console.WriteLine(oldContactList.ToString());
            Assert.AreEqual(oldContactList, newContactList);

        }

        [Test]
        public void RemoveContactFromGroup()
        {
            var groups = app.GroupHelper.GetGroupsWithContacts();
            if (groups.Count == 0)
            {
                GroupData group = app.GroupHelper.GetGroupsFromDB()[0];
                ContactData contact = app.ContactHelper.GetContactsFromDB()[0];
                app.ContactHelper.AddContactToGroup(contact, group);
                groups = app.GroupHelper.GetGroupsWithContacts();
            }
            else
            {
                var contactsInGroup = app.GroupHelper.GetContactsInGroup(groups[0].Id);
                var contactToBeRemoved = contactsInGroup[0];
                app.ContactHelper.RemoveContactFromGroup(groups[0], contactToBeRemoved);
                contactsInGroup.Remove(contactToBeRemoved);
                var newContactsInGroup = app.GroupHelper.GetContactsInGroup(groups[0].Id);
                newContactsInGroup.Sort();
                contactsInGroup.Sort();
                Assert.AreEqual(contactsInGroup, newContactsInGroup);




            }
        }
    }
}
