﻿using NUnit.Framework;
using System;

namespace addressbook_tests.tests
{
    [TestFixture]
    public class ContactInformationTests : AuthTestBase
    {
        [Test]
        public void TestContactInformationFromForm()
        {
            ContactData fromTable = app.ContactHelper.GetContactInformationFromTable(4);
            ContactData fromForm = app.ContactHelper.GetContactInformationFromEditForm(4);
            Assert.AreEqual(fromTable, fromForm);
            Assert.AreEqual(fromTable.Address, fromForm.Address);
            Assert.AreEqual(fromTable.AllPhones, fromForm.AllPhones);
        }

        [Test]
        public void TestContactInformationFromViewPage()
        {
            ContactData fromTable = app.ContactHelper.GetContactInformationFromTable(4);
            ContactData fromViewPage = app.ContactHelper.GetContactInformationFromViewContactPage(4);

            Assert.AreEqual(fromTable.AllContactDetails, fromViewPage.AllContactDetails);
        }
    }
}
