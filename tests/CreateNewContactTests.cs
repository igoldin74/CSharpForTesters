﻿using NUnit.Framework;


namespace addressbook_tests
{
        [TestFixture]
        public class CreateNewContactTests : AuthTestBase
        {
            [Test]
            public void CreateNewContactTest()
            {
                var oldContacts = app.ContactHelper.GetContacts();
                ContactData newContact = new ContactData("test_f_name", "test_l_name");

                app.ContactHelper.
                        InitContactCreation().
                        FillOutContactForm(newContact).
                        SubmitNewContactForm();

                Assert.AreEqual(oldContacts.Count + 1, app.ContactHelper.GetContactCount());

                var newContacts = app.ContactHelper.GetContacts();
                oldContacts.Add(newContact);
                oldContacts.Sort();
                newContacts.Sort();

                Assert.AreEqual(oldContacts, newContacts);  
             }

        }
}