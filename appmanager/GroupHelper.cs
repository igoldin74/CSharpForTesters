using System;
using System.Collections.Generic;
using OpenQA.Selenium;
namespace addressbook_tests
{
    public class GroupHelper : HelperBase
    {

        public GroupHelper(ApplicationManager manager) : base(manager)
        {
        }

        public GroupHelper Create(GroupData group)
        {
            manager.NavigationHelper.OpenGroupsPage();
            InitGroupCreation();
            FillOutGroupData(group);
            SubmitGroupCreation();
            return this;

        }

        public GroupHelper SubmitGroupCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            return this;
        }

        public GroupHelper FillOutGroupData(GroupData group)
        {
            Type(By.Name("group_name"), group.Name);
            Type(By.Name("group_header"), group.Header);
            Type(By.Name("group_footer"), group.Footer);
            return this;
        }

        public GroupHelper InitGroupCreation()
        {
            driver.FindElement(By.Name("new")).Click();
            return this;
        }

        public GroupHelper SelectRandomGroup()
        {
            var elements = driver.FindElements(By.Name("selected[]"));
            elements[new Random().Next(elements.Count)].Click();
            return this;
        }

        public GroupHelper SelectGroupByIndex(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + (index + 1) + "]")).Click();
            return this;
        }

        public GroupHelper InitGroupModification()
        {
            driver.FindElement(By.Name("edit")).Click();
            return this;
        }

        public GroupHelper SubmitGroupModification()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }

        public GroupHelper RemoveSelectedGroup()
        {
            driver.FindElement(By.Name("delete")).Click();
            return this;
        }

        public bool AreThereGroups()
        {
            return AreElementsPresent(By.Name("selected[]"));
        }

        public List<GroupData> GetGroups()
        {
            List<GroupData> groups = new List<GroupData>();
            ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("span.group"));
            foreach (IWebElement element in elements)
            {
                groups.Add(new GroupData(element.Text));
            }
            return groups;
        }
    }
}
