using OpenQA.Selenium;

namespace addressbook_tests
{
    public class ContactHelper : HelperBase
    {

        public ContactHelper(IWebDriver driver) : base(driver)
        {
        }

        public void SubmitNewContactForm()
        {
            driver.FindElements(By.CssSelector("[name = 'submit']"))[1].Click();
        }

        public void FillOutNewContactForm(ContactData contact)
        {
            driver.FindElement(By.Name("firstname")).Click();
            driver.FindElement(By.Name("firstname")).Clear();
            driver.FindElement(By.Name("firstname")).SendKeys(contact.FirstName);
            driver.FindElement(By.Name("lastname")).Clear();
            driver.FindElement(By.Name("lastname")).SendKeys(contact.FirstName);
        }

        public void InitContactCreation()
        {
            driver.FindElement(By.LinkText("add new")).Click();
        }
    }
}
