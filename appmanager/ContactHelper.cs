using System;
using System.Collections.Generic;
using OpenQA.Selenium;

namespace addressbook_tests
{
    public class ContactHelper : HelperBase
    {

        public ContactHelper(ApplicationManager manager) : base(manager)
        {
        }

        public ContactHelper SubmitNewContactForm()
        {
            driver.FindElements(By.CssSelector("[name = 'submit']"))[1].Click();
            return this;
        }

        public ContactHelper SubmitContactModification()
        {
            driver.FindElements(By.CssSelector("[name = 'update']"))[1].Click();
            return this;
        }

        public ContactHelper FillOutContactForm(ContactData contact)
        {
            Type(By.Name("firstname"), contact.FirstName);
            Type(By.Name("lastname"), contact.LastName);
            return this;
        }

        public ContactHelper InitRandomContactModification()
        {
            var elements = driver.FindElements(By.XPath("//a[contains(@href, 'edit.php?id')]"));
            elements[new Random().Next(elements.Count)].Click();
            return this;
        }

        public ContactHelper InitContactModificationByIndex(int index)
        {
            var elements = driver.FindElements(By.XPath("//a[contains(@href, 'edit.php?id')]"));
            elements[index].Click();
            return this;
        }

        public ContactHelper SelectRandomContact()
        {
            var elements = driver.FindElements(By.Name("selected[]"));
            elements[new Random().Next(elements.Count)].Click();
            return this;
        }

        public ContactHelper SelectContactByIndex(int index)
        {
            var elements = driver.FindElements(By.Name("selected[]"));
            elements[index].Click();
            return this;
        }

        public ContactHelper DeleteRandomContact()
        {
            SelectRandomContact();
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            driver.SwitchTo().Alert().Accept();
            return this;
        }

        public ContactHelper DeleteContactByIndex(int index)
        {
            SelectContactByIndex(index);
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            driver.SwitchTo().Alert().Accept();
            return this;
        }

        public ContactHelper InitContactCreation()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }

        public bool AreThereContacts()
        {
            return AreElementsPresent(By.Name("selected[]"));
        }

        public List<ContactData> GetContacts()
        {
            List<ContactData> contacts = new List<ContactData>();
            ICollection<IWebElement> elements = driver.FindElements(By.Name("entry"));
            foreach (IWebElement element in elements)
            {
                var cells = element.FindElements(By.TagName("td"));
                contacts.Add(new ContactData(cells[2].Text, cells[1].Text));
            }
            return contacts;
        }
    }
}
