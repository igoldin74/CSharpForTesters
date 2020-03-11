using OpenQA.Selenium;

namespace addressbook_tests
{
    public class HelperBase
    {
        protected IWebDriver driver;

        public HelperBase(IWebDriver driver)
        {
            this.driver = driver;
        }
    }
}
