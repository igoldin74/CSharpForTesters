using OpenQA.Selenium;
using System;
using System.Collections.Generic;
namespace addressbook_tests
{
    public class GroupHelper : HelperBase
    {

        public GroupHelper(ApplicationManager manager) : base(manager)
        {
        }

        public GroupHelper Create(GroupData group)
        {
            InitGroupCreation();
            FillOutGroupData(group);
            SubmitGroupCreation();
            return this;
        }

        public GroupHelper SubmitGroupCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            groupCache = null;
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
            groupCache = null;
            return this;
        }

        public GroupHelper RemoveSelectedGroup()
        {
            driver.FindElement(By.Name("delete")).Click();
            groupCache = null;
            return this;
        }

        public bool AreThereGroups()
        {
            return AreElementsPresent(By.Name("selected[]"));
        }

        private List<GroupData> groupCache = null;

        public List<GroupData> GetGroups()
        {
            if (groupCache == null)
            {
                groupCache = new List<GroupData>();
                manager.NavigationHelper.OpenGroupsPage();
                ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("span.group"));
                foreach (IWebElement element in elements)
                {
                    element.FindElement(By.TagName("input")).GetAttribute("value");
                    groupCache.Add(new GroupData(element.Text)
                    {
                        Id =
                        int.Parse(element.FindElement(By.TagName("input")).GetAttribute("value"))
                    });
                }
            }
            return new List<GroupData>(groupCache);
        }

        // Optimized alternative to GetGroups() method:
        public List<GroupData> GetGroupsAlt()
        {
            if (groupCache == null)
            {
                groupCache = new List<GroupData>();
                manager.NavigationHelper.OpenGroupsPage();
                ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("span.group"));
                foreach (IWebElement element in elements)
                {
                    element.FindElement(By.TagName("input")).GetAttribute("value");
                    groupCache.Add(new GroupData(null)
                    {
                        Id =
                        int.Parse(element.FindElement(By.TagName("input")).GetAttribute("value"))
                    });
                }
                string allGroupNames = driver.FindElement(By.CssSelector("div#content form")).Text;
                string[] names = allGroupNames.Split('\n');
                // To account for groups with blank names, we find how many have blank names:
                int shift = groupCache.Count - names.Length;
                for (int i = 0; i < groupCache.Count; i++)
                {
                    if (i < shift)
                    {
                        groupCache[i].Name = "";
                    }
                    groupCache[i].Name = names[i - shift].Trim();
                }
            }
            return new List<GroupData>(groupCache);
        }

        public int GetGroupCount()
        {
            manager.NavigationHelper.OpenGroupsPage();
            return driver.FindElements(By.CssSelector("span.group")).Count;
        }
    }
}
