using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

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
            string email1 = driver.FindElement(By.Name("email")).GetAttribute("value");
            string email2 = driver.FindElement(By.Name("email2")).GetAttribute("value");
            string email3 = driver.FindElement(By.Name("email3")).GetAttribute("value");

            return new ContactData(firstName, lastName)
            {
                Address = address,
                HomePhone = homePhone,
                MobilePhone = mobilePhone,
                WorkPhone = workPhone,
                Email1 = email1,
                Email2 = email2,
                Email3 = email3
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

            manager.NavigationHelper.OpenHomePage();
            OpenViewPageByIndex(index);
            string contactData = driver.FindElement(By.CssSelector("#content")).Text;
            //string contactData = lines.Replace("\n", "");
            Regex regex = new Regex("[HWM:\n ]");
            string cleanContactData = regex.Replace(contactData, "");

            return new ContactData(contactData);
        }

        public List<ContactData> GetContactsFromDB()
        {
            using (AddressBookDB db = new AddressBookDB())
            {
                return (from c in db.Contacts select c).ToList();
            }

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

        public ContactHelper InitContactModificationById(int id)
        {
            driver.FindElement(By.XPath(String.Format("//a[contains(@href, 'edit.php?id={0}')]", id))).Click();
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

        public ContactHelper SelectContactById(int id)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]' and @value='" + id + "'])")).Click();
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

        public ContactHelper DeleteContactById(int id)
        {
            SelectContactById(id);
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
