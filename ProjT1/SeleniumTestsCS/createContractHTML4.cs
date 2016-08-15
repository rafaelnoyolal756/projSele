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
    public class CreateContractHTML2
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
        public void TheCreateContractHTML2Test()
        {
            driver.Navigate().GoToUrl(baseURL + "CS/");
            driver.FindElement(By.LinkText("Log In")).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.Id("UserName")).Clear();
            driver.FindElement(By.Id("UserName")).SendKeys("rafael.noyola@creativaconsultores.com");
            driver.FindElement(By.Id("Password")).Clear();
            driver.FindElement(By.Id("Password")).SendKeys("Admin1234!");
            driver.FindElement(By.Id("SubmitLogin")).Click();
            Thread.Sleep(5000);
            Assert.AreEqual("You logged in successfully.", driver.FindElement(By.XPath("//body/div[2]/div")).Text);
            driver.FindElement(By.LinkText("rafael")).Click();
            driver.FindElement(By.Id("view-link")).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.XPath("(//a[contains(text(),'Contracts')])[2]")).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.XPath("(//button[@type='button'])[4]")).Click();
            driver.FindElement(By.LinkText("Import HTML File Contract")).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.Id("Title")).Clear();
            driver.FindElement(By.Id("Title")).SendKeys("Test contract html");
            driver.FindElement(By.Id("TaxonomyButton")).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.XPath("//li[@id='24']/i")).Click();
            Thread.Sleep(5000);
            //driver.FindElement(By.CssSelector("#24 > i.jstree-icon.jstree-ocl")).Click();
            //driver.FindElement(By.CssSelector("#25 > i.jstree-icon.jstree-ocl")).Click();
            //Console.Write("li[@id='24']/i");
            driver.FindElement(By.Id("24_anchor")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//div[4]/div[2]/button")).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.LinkText("rafael")).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.LinkText("Log Out")).Click();
            //driver.FindElement(By.Id("HtmlFileButton")).Clear();
            //driver.FindElement(By.Id("HtmlFileButton")).SendKeys("C:\\Users\\rafael.noyola\\Documents\\sele test\\CS uploadtests\\Tests\\examples\\uploads\\contracts\\End User License Agreement.html");
            //driver.FindElement(By.XPath("//div[4]/div[2]/button[2]")).Click();
            //driver.FindElement(By.Id("SubmitContract")).Click();
            //Assert.AreEqual("Contract added successfully.", driver.FindElement(By.XPath("//body/div[2]/div")).Text);
            //Assert.AreEqual("Test Contract Html", driver.Title);
            //Assert.AreEqual("End User License Agreement", driver.FindElement(By.CssSelector("p.title.L1")).Text);
            //Assert.AreEqual("Please read this agreement carefully. It contains important terms that affect you and your use of the Software. By clicking, \"I accept\" or by installing, copying, or using the Software, you agree to be bound by the terms of this agreement, including the disclaimers. If you do not agree to these terms, do not install, copy, or use the software.", driver.FindElement(By.XPath("//div[@id='contract']/p[3]")).Text);
            //driver.FindElement(By.Id("DeleteContractButton")).Click();
            //driver.FindElement(By.XPath("//div[4]/div[2]/button")).Click();
            //Assert.AreEqual("Original Contract deleted successfully.", driver.FindElement(By.XPath("//body/div[2]/div")).Text);
            //driver.FindElement(By.LinkText("rafael")).Click();
            //driver.FindElement(By.LinkText("Log Out")).Click();
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
