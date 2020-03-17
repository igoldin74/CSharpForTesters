﻿using OpenQA.Selenium;

namespace addressbook_tests
{
    public class SessionHelper : HelperBase
    {

        public SessionHelper(ApplicationManager manager) : base(manager)
        {
        }

        public void Login(AccountData account)
        {
            Type(By.Name("user"), account.Username);
            Type(By.Name("pass"), account.Password);
            driver.FindElement(By.XPath("//input[@value='Login']")).Click();
        }

        public void Logout()
        {
            driver.FindElement(By.LinkText("Logout")).Click();
        }



    }
}
