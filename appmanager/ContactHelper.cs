using System;
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

        public ContactHelper SelectRandomContact()
        {
            var elements = driver.FindElements(By.Name("selected[]"));
            elements[new Random().Next(elements.Count)].Click();
            return this;
        }

        public ContactHelper DeleteRandomContact()
        {
            SelectRandomContact();
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
    }
}
