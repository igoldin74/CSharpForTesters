using OpenQA.Selenium;

namespace addressbook_tests
{
    public class NavigationHelper : HelperBase
    {
        private string baseURL;


        public NavigationHelper(ApplicationManager manager) : base(manager)
        {
            this.baseURL = manager.BaseURL;
        }

        public void OpenHomePage()
        {
            if (driver.Url == baseURL + "/addressbook/")
            {
                return;
            }

            driver.Navigate().GoToUrl(baseURL + "/addressbook/");
        }

        public void OpenGroupsPage()
        {
            if (driver.Url == baseURL + "/addressbook/group.php"
                && IsElementPresent(By.Name("new")))
            {
                return;
            }

            driver.FindElement(By.LinkText("groups")).Click();
        }

        public void ClickOnHomePageLink()
        {
            if (driver.Url == baseURL + "/addressbook/index.php")
            {
                return;
            }

            driver.FindElement(By.LinkText("home")).Click();
        }

    }
}
