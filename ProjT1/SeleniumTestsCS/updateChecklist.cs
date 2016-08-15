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
    public class UpdateChecklist
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
        public void TheUpdateChecklistTest()
        {
            driver.Navigate().GoToUrl(baseURL + "CS/");
            driver.FindElement(By.LinkText("Log In")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.Id("UserName")).Clear();
            driver.FindElement(By.Id("UserName")).SendKeys("rafael.noyola@creativaconsultores.com");
            driver.FindElement(By.Id("Password")).Clear();
            driver.FindElement(By.Id("Password")).SendKeys("Admin1234!");
            driver.FindElement(By.Id("SubmitLogin")).Click();
            Thread.Sleep(3000);
            
            try
            {
                Assert.AreEqual("You logged in successfully.", driver.FindElement(By.XPath("//body/div[2]/div")).Text);
                Console.WriteLine("You logged in successfully.");
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            
            driver.FindElement(By.LinkText("rafael")).Click();
            driver.FindElement(By.Id("view-link")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("(//a[contains(text(),'Checklists')])[2]")).Click();
            driver.FindElement(By.CssSelector("input.form-control.input-sm")).Clear();
            Thread.Sleep(1000);
            driver.FindElement(By.CssSelector("input.form-control.input-sm")).SendKeys("Test Consistency");
            
            try
            {
                Assert.IsTrue(IsElementPresent(By.LinkText("Test Consistency")));
                Console.WriteLine("Test Consistency - FOUND");
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            Thread.Sleep(1000);
            driver.FindElement(By.LinkText("Test Consistency")).Click();
            Thread.Sleep(4000);
            driver.FindElement(By.LinkText("Go Edit Checklist")).Click();
            Thread.Sleep(4000);
            //driver.FindElement(By.XPath("//table[@id='dataTableAllChecklistsList']/tbody/tr[2]/td[3]/a/span")).Click();

            try
            {
                Assert.AreEqual("Update", driver.FindElement(By.Id("SubmitUpdateChecklist")).Text);
                //Console.WriteLine("");
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            driver.FindElement(By.Id("ChecklistFileButton")).Clear();
            driver.FindElement(By.Id("ChecklistFileButton")).SendKeys("C:\\CS uploadtests\\Tests\\examples\\uploads\\checklists\\change-in-control-new2UPDATE.json");
            driver.FindElement(By.Id("SubmitUpdateChecklist")).Click();
            Thread.Sleep(4000);
            try
            {
                Assert.AreEqual("Checklist updated successfully.", driver.FindElement(By.XPath("//body/div[2]/div")).Text);
                Console.WriteLine("Checklist updated successfully.");
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            // ERROR: Caught exception [unknown command []]
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
        
        private string CloseAlertAndGetItsText() {
            try {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert) {
                    alert.Accept();
                } else {
                    alert.Dismiss();
                }
                return alertText;
            } finally {
                acceptNextAlert = true;
            }
        }
    }
}
