using OpenQA.Selenium;

namespace addressbook_tests
{
    public class NavigationHelper : HelperBase
    {
        private string baseURL;


        public NavigationHelper(IWebDriver driver, string baseURL) : base(driver)
        {
            this.baseURL = baseURL;
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
