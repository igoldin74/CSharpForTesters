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
            driver.Navigate().GoToUrl(baseURL);
        }

        public void OpenGroupsPage()
        {
            driver.FindElement(By.LinkText("groups")).Click();
        }

        public void ClickOnHomePageLink()
        {
            driver.FindElement(By.LinkText("home page")).Click();
        }
    }
}
