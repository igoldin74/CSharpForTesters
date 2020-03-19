using System;
using System.Threading;
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
        // Storage for our thread designated application manager object:
        private static ThreadLocal<ApplicationManager> app = new ThreadLocal<ApplicationManager>();

        public SessionHelper SessionHelper { get => sessionHelper; }
        public NavigationHelper NavigationHelper { get => navigationHelper; }
        public ContactHelper ContactHelper { get => contactHelper; }
        public GroupHelper GroupHelper { get => groupHelper; }
        public IWebDriver Driver { get => driver; }
        public string BaseURL { get => baseURL; }

        // Making constructor method private:
        private ApplicationManager()
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
                driver.Dispose();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close browser
            }
        }


        // Public method to be used in TestSuiteFixture where we initialize
        // application manager using our private constructor:
        public static ApplicationManager GetInstance()
        {
            if (! app.IsValueCreated)
            {
                ApplicationManager newInstance = new ApplicationManager();
                newInstance.NavigationHelper.OpenHomePage();
                app.Value = newInstance;
            }
            return app.Value;
        }

        // Destructor method. Called for each ApplicationManager object.
        // Currently there's a bug in Selenium code that fails to call Quit() or Dispose() method from destructor.
        //~ApplicationManager()
        //{
        //    SessionHelper.Logout();
        //    Stop();
        //}
    }
}
