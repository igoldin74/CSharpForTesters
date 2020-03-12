using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace addressbook_tests
{
    public class ApplicationManager
    {
        private IWebDriver driver;
        private string baseURL;
        private SessionHelper sessionHelper;
        private NavigationHelper navigationHelper;
        private ContactHelper contactHelper;
        private GroupHelper groupHelper;

        public SessionHelper SessionHelper { get => sessionHelper; }
        public NavigationHelper NavigationHelper { get => navigationHelper; }
        public ContactHelper ContactHelper { get => contactHelper; }
        public GroupHelper GroupHelper { get => groupHelper; }
        public IWebDriver Driver { get => driver; }
        public string BaseURL { get => baseURL; }

        public ApplicationManager()
        {
            driver = new ChromeDriver();
            baseURL = "http://localhost/addressbook";
            sessionHelper = new SessionHelper(this);
            navigationHelper = new NavigationHelper(this);
            contactHelper = new ContactHelper(this);
            groupHelper = new GroupHelper(this);
        }

        public void Stop()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close browser
            }
        }
    }
}
