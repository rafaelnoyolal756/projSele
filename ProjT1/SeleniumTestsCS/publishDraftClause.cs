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
    public class PublishDraftClause
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;
        
        [SetUp]
        public void SetupTest()
        {
            driver = new ChromeDriver();
            
            driver.Manage().Window.Maximize();
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
        public void ThePublishDraftClauseTest()
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
            Assert.AreEqual("You logged in successfully.", driver.FindElement(By.XPath("//body/div[2]/div")).Text);
            driver.FindElement(By.LinkText("rafael")).Click();
            Thread.Sleep(4000);
            driver.FindElement(By.Id("view-link")).Click();
            Thread.Sleep(4000);
            driver.FindElement(By.XPath("(//a[contains(text(),'Clauses')])[2]")).Click();
            Thread.Sleep(4000);
            new SelectElement(driver.FindElement(By.Id("dataTableClausesAll-Status-select-search"))).SelectByText("My Draft");
            Thread.Sleep(4000);
            driver.FindElement(By.LinkText("Acceptance of Terms of Service Copy")).Click();///Access to Information Copy
            Thread.Sleep(4000);
            driver.FindElement(By.LinkText("Draft")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.LinkText("Publish")).Click();
            //driver.FindElement(By.CssSelector("#ClausePrimaryButton > btn btn-sm btn - success")).Click();///////PUBLISH DRAFT
            //Thread.Sleep(20000);"button-status" data-button-status="Publish"
            //driver.FindElement(By.CssSelector("#ClausePrimaryButton > span.button-status")).Click();
            Thread.Sleep(3000);
            try
            {
                Assert.AreEqual("Clause approved and published successfully.", driver.FindElement(By.XPath("//body/div[2]/div")).Text);
                Console.WriteLine("Clause approved and published successfully.");
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            driver.FindElement(By.LinkText("rafael")).Click();
            driver.FindElement(By.LinkText("Log Out")).Click();

            driver.FindElement(By.Id("ClauseTaxonomyButton")).Click();

            //IJavaScriptExecutor jse = driver as IJavaScriptExecutor;
            // jse.ExecuteScript("window.scrollBy(0,250)");
            //jse.ExecuteScript("arguments[0].scrollTop = arguments[1];", driver.FindElement(By.Id("ajs-dialog")), 100); <div class="ajs-dialog"
            //((JavascriptExecutor) driver).executeScript("arguments[0].scrollIntoView(true);", element);
            // < div class="bootstrap-dialog-footer-buttons">
            //By.XPath("//div[@class='bootstrap-dialog-footer-buttons']//button[text()='Yes']")

            Thread.Sleep(4000);
            //driver.FindElement(By.Id("271_anchor")).Click();/////
            driver.FindElement(By.XPath("//a[@id='271_anchor']/i")).Click();
            //driver.FindElement(By.CssSelector("#307 > i.jstree-icon.jstree-ocl")).Click();////
            Thread.Sleep(3000);
            //driver.FindElement(By.XPath("//a[@id='308_anchor']/i")).Click();//////
            driver.FindElement(By.XPath("//div[4]/div[2]/button")).Click();
            Thread.Sleep(4000);
            driver.FindElement(By.LinkText("Cancel")).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.Id("dataTableClausesAll-Status-select-search")).Click();
            new SelectElement(driver.FindElement(By.Id("dataTableClausesAll-Status-select-search"))).SelectByText("My Draft");
            driver.FindElement(By.LinkText("Acceptance Copy 2 Copy Copy")).Click();
            //// ERROR: Caught exception [ERROR: Unsupported command [isSomethingSelected |  | ]]
            
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
