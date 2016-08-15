using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;

namespace SeleniumTests
{
    [TestFixture]
    public class resgisterEmail
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;

        [SetUp]
        public void SetupTest()
        {
            driver = new ChromeDriver();
            baseURL = "http://54.173.64.156/";
            verificationErrors = new StringBuilder();
            driver.Manage().Window.Maximize();
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
        public void TheResgisterEmailTest()
        {
            driver.Navigate().GoToUrl(baseURL + "CS/");
            driver.FindElement(By.LinkText("Log In")).Click();
            Thread.Sleep(3000);
            Console.WriteLine("Login");
            driver.FindElement(By.Id("UserName")).Clear();
            driver.FindElement(By.Id("UserName")).SendKeys("rafael.noyola@creativaconsultores.com");
            driver.FindElement(By.Id("Password")).Clear();
            driver.FindElement(By.Id("Password")).SendKeys("Admin1234!");
            Thread.Sleep(4000);
            driver.FindElement(By.Id("SubmitLogin")).Click();
            Thread.Sleep(5000);
            Assert.AreEqual("You logged in successfully.", driver.FindElement(By.XPath("//body/div[2]/div")).Text);
            //Console.WriteLine("You logged in successfully.");
            Thread.Sleep(4000);
            driver.FindElement(By.LinkText("rafael")).Click();
            Thread.Sleep(2000);
            //driver.FindElement(By.XPath("//div[@id='theNavbar']/ul/li[5]/a/span")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.Id("view-link")).Click();
            Thread.Sleep(4000);
            driver.FindElement(By.XPath("(//a[contains(text(),'Clauses')])[2]")).Click();
            Thread.Sleep(7000);
            driver.FindElement(By.XPath("(//button[@type='button'])[4]")).Click();
            Thread.Sleep(4000);
            driver.FindElement(By.LinkText("Add New Clause")).Click();
            Thread.Sleep(4000);
            driver.FindElement(By.Id("Heading")).Clear();
            driver.FindElement(By.Id("Heading")).SendKeys("Test Agreement Clause");
            driver.FindElement(By.LinkText("rafael")).Click();
            driver.FindElement(By.LinkText("Log Out")).Click();
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
