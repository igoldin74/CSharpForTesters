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
            contactCache = null;
            return this;
        }

        internal ContactData GetContactInformationFromEditForm(int index)
        {
            manager.NavigationHelper.OpenHomePage();
            InitContactModificationByIndex(index);
            string firstName = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string lastName = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");
            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");

            return new ContactData(firstName, lastName)
            {
                Address = address,
                HomePhone = homePhone,
                MobilePhone = mobilePhone,
                WorkHome = workPhone
            };
        }

        internal ContactData GetContactInformationFromTable(int index)
        {
            manager.NavigationHelper.OpenHomePage();
            IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"));
            string lastName = cells[1].Text;
            string firstName = cells[2].Text;
            string address = cells[3].Text;
            string allPhones = cells[5].Text;
            return new ContactData(firstName, lastName)
            {
                Address = address,
                AllPhones = allPhones
            };
        }

        internal ContactData GetContactInformationFromViewContactPage(int index)
        {
            string homePhone = null;
            string mobilePhone = null;
            string workPhone = null;
            manager.NavigationHelper.OpenHomePage();
            OpenViewPageByIndex(index);
            string[] lines = driver.FindElement(By.CssSelector("#content")).Text.Split('\n');
            string fullName = lines[0].Replace(" ", "");
            string address;
            if (lines.Length == 1)
            {
                address = "";
            }
            else
            {
                address = lines[1];
            }


            foreach (string l in lines)
            {
                if (l.StartsWith("H:"))
                {
                    homePhone = l.Substring(3);
                }
                if (l.StartsWith("M:"))
                {
                    mobilePhone = l.Substring(3);
                }
                if (l.StartsWith("W:"))
                {
                    workPhone = l.Substring(3);
                }
            }

            return new ContactData()
            {
                FullName = fullName,
                Address = address,
                HomePhone = homePhone,
                MobilePhone = mobilePhone,
                WorkHome = workPhone,
            };
        }

        public ContactHelper SubmitContactModification()
        {
            driver.FindElements(By.CssSelector("[name = 'update']"))[1].Click();
            contactCache = null;
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

        public ContactHelper OpenViewPageByIndex(int index)
        {
            var elements = driver.FindElements(By.XPath("//a[contains(@href, 'view.php?id')]"));
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
            contactCache = null;
            return this;
        }

        public ContactHelper DeleteContactByIndex(int index)
        {
            SelectContactByIndex(index);
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            driver.SwitchTo().Alert().Accept();
            contactCache = null;
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

        private List<ContactData> contactCache = null;

        public List<ContactData> GetContacts()
        {
            if (contactCache == null)
            {
                manager.NavigationHelper.ClickOnHomePageLink();
                contactCache = new List<ContactData>();
                ICollection<IWebElement> elements = driver.FindElements(By.Name("entry"));
                foreach (IWebElement element in elements)
                {
                    var cells = element.FindElements(By.TagName("td"));
                    contactCache.Add(new ContactData(cells[2].Text, cells[1].Text));
                }
            }
            return new List<ContactData>(contactCache);
        }

        public int GetContactCount()
        {
            manager.NavigationHelper.ClickOnHomePageLink();
            return driver.FindElements(By.Name("entry")).Count;
        }
    }
}
