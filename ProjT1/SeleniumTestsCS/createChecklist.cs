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
    public class CreateChecklist
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
        public void TheCreateChecklistTest()
        {
            driver.Navigate().GoToUrl(baseURL + "CS/");
            driver.FindElement(By.LinkText("Log In")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.Id("UserName")).Clear();
            driver.FindElement(By.Id("UserName")).SendKeys("rafael.noyola@creativaconsultores.com");
            driver.FindElement(By.Id("Password")).Clear();
            driver.FindElement(By.Id("Password")).SendKeys("Admin1234!");
            driver.FindElement(By.Id("SubmitLogin")).Click();
            Thread.Sleep(5000);
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
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("(//a[contains(@href, '/CS/checklists/new')])[2]")).Click();
            //span class="pull-right"
            //<a class="btn btn-sm btn-success" href="/CS/checklists/new">
            driver.FindElement(By.Id("Title")).Clear();
            driver.FindElement(By.Id("Title")).SendKeys("Test Consistency");
            //driver.FindElement(By.Id("ChecklistFileButton")).Clear();
            try
            {
                driver.FindElement(By.Id("ChecklistFileButton")).SendKeys("C:\\CS uploadtests\\Tests\\examples\\uploads\\checklists\\change-in-control-new2.json");
                Console.WriteLine("Uploaded change-in-control-new2.json file");
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            Thread.Sleep(3000);
            //try
            //{
            //    Assert.IsTrue(IsElementPresent(By.CssSelector("pre.file - preview - text")));
            //   // Console.WriteLine(" pre.file - preview - text - Found");
            //}
            //catch (AssertionException e)
            //{
            //    verificationErrors.Append(e.Message);

            //}
           
            //try
            //{
            //    Assert.AreEqual("[\n {\n \"refset\": \"CS-CICTEST\",\n \"parent\": null,\n \"child\": [],\n \"data_tcg\": \"_TB9eeda4d0-28ea-4d8f-950a-3154e60f60bb\",\n \"heading\": \"Definitions TEST\",\n \"commonality\": \"43\",\n \"consistency\": \"58\",\n \"status\": \"S\",\n \"flagged\": false\n },\n {\n \"refset\": \"CS-CICTEST\",\n \"parent\": null", driver.FindElement(By.CssSelector("pre.file-preview-text")).Text);
            //    Console.WriteLine("checklist json verified");
            //}
            //catch (AssertionException e)
            //{
            //    verificationErrors.Append(e.Message);
            //}
            Thread.Sleep(3000);
            //driver.FindElement(By.XPath("//div[4]/div[2]/button[2]")).Click();
            driver.FindElement(By.Id("SubmitChecklist")).Click();
            //driver.FindElement(By.CssSelector("#SubmitChecklist > btn btn-sm btn-primary")).Click();
            //driver.FindElement(By.Id("SubmitChecklist")).Click();
            Thread.Sleep(4000);
            try
            {
                Assert.AreEqual("Checklist added successfully.", driver.FindElement(By.XPath("//body/div[2]/div")).Text);
                Console.WriteLine("Checklist added successfully.");
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            Thread.Sleep(3000);
            try
            {
                Assert.AreEqual("Testchangeincontrol2 Checklist", driver.Title);
                Console.WriteLine("Title Testchangeincontrol2 Checklist - verified.");
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            Thread.Sleep(3000);
            try
            {
                Assert.AreEqual("CS-CICTEST", driver.FindElement(By.Id("Refset")).GetAttribute("value"));
                Console.WriteLine("Reference standard value CS-CICTEST verified.");
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            Thread.Sleep(3000);
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
