﻿using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace addressbook_tests
{
        [TestFixture]
        public class CreateNewContactTests
        {
            private IWebDriver driver;
            private StringBuilder verificationErrors;
            private string baseURL;
            private bool acceptNextAlert = true;

            [SetUp]
            public void SetupTest()
            {
                driver = new ChromeDriver();
                baseURL = "http://localhost/addressbook/";
                verificationErrors = new StringBuilder();
            }

            [TearDown]
            public void TeardownTest()
            {
                try
                {
                    driver.Quit();
                }
                catch (Exception)
                {
                    // Ignore errors if unable to close the browser
                }
                Assert.AreEqual("", verificationErrors.ToString());
            }

            [Test]
            public void CreateNewContactTest()
            {
                OpenHomePage();
                Login(new AccountData("admin", "secret"));
                InitContactCreation();
                ContactData newContact = new ContactData("test_f_name", "test_l_name");
                FillOutNewContactForm(newContact);
                SubmitNewContactForm();
                ClickOnHomePageLink();
                Logout();
             }

            private void ClickOnHomePageLink()
            {
                driver.FindElement(By.LinkText("home page")).Click();
            }

            private void SubmitNewContactForm()
            {
                driver.FindElements(By.CssSelector("[name = 'submit']"))[1].Click();
            }

            private void FillOutNewContactForm(ContactData contact)
            {
                driver.FindElement(By.Name("firstname")).Click();
                driver.FindElement(By.Name("firstname")).Clear();
                driver.FindElement(By.Name("firstname")).SendKeys(contact.FirstName);
                driver.FindElement(By.Name("lastname")).Clear();
                driver.FindElement(By.Name("lastname")).SendKeys(contact.FirstName);
            }

            private void InitContactCreation()
            {
                driver.FindElement(By.LinkText("add new")).Click();
            }

            private void Logout()
            {
                driver.FindElement(By.LinkText("Logout")).Click();
            }

            private void Login(AccountData account)
            {
                driver.FindElement(By.Name("user")).Click();
                driver.FindElement(By.Name("user")).Clear();
                driver.FindElement(By.Name("user")).SendKeys(account.Username);
                driver.FindElement(By.Name("pass")).Clear();
                driver.FindElement(By.Name("pass")).SendKeys(account.Password);
                driver.FindElement(By.XPath("//input[@value='Login']")).Click();
            }

            private void OpenHomePage()
            {
                driver.Navigate().GoToUrl(baseURL);
            }

            private bool IsElementPresent(By by)
            {
                try
                {
                    driver.FindElement(by);
                    return true;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
            }

            private bool IsAlertPresent()
            {
                try
                {
                    driver.SwitchTo().Alert();
                    return true;
                }
                catch (NoAlertPresentException)
                {
                    return false;
                }
            }

            private string CloseAlertAndGetItsText()
            {
                try
                {
                    IAlert alert = driver.SwitchTo().Alert();
                    string alertText = alert.Text;
                    if (acceptNextAlert)
                    {
                        alert.Accept();
                    }
                    else
                    {
                        alert.Dismiss();
                    }
                    return alertText;
                }
                finally
                {
                    acceptNextAlert = true;
                }
            }
        }
}