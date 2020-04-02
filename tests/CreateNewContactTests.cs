﻿using System.Collections.Generic;
using NUnit.Framework;


namespace addressbook_tests
{
        [TestFixture]
        public class CreateNewContactTests : AuthTestBase
        {

        public static IEnumerable<ContactData> RandomContactDataProvider()
        {
            List<ContactData> contacts = new List<ContactData>();
            for (int i = 0; i < 5; i++)
            {
                contacts.Add(new ContactData(GenerateRandomString(10), GenerateRandomString(10))
                {
                    Address = GenerateRandomString(20),
                    MobilePhone = GenerateRandomString(10)
                });
            }
            return contacts;
        }
        [Test, TestCaseSource("RandomContactDataProvider")]
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