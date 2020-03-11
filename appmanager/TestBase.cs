using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace addressbook_tests
{
    public class TestBase
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;

        protected SessionHelper sessionHelper;
        protected NavigationHelper navigationHelper;
        protected ContactHelper contactHelper;
        protected GroupHelper groupHelper;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            baseURL = "http://localhost/addressbook/";
            verificationErrors = new StringBuilder();
            sessionHelper = new SessionHelper(driver);
            navigationHelper = new NavigationHelper(driver, baseURL);
            contactHelper = new ContactHelper(driver);
            groupHelper = new GroupHelper(driver);
        }

        [TearDown]
        public void Teardown()
        {
            driver.Quit();
        }
    
    }
}
