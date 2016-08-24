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
    public class CreateClausePrivate
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
        public void TheCreateClausePrivateTest()
        {
            driver.Navigate().GoToUrl(baseURL + "CS/");
            driver.FindElement(By.LinkText("Log In")).Click();
            Thread.Sleep(4000);
            driver.FindElement(By.Id("UserName")).Clear();
            driver.FindElement(By.Id("UserName")).SendKeys("rafael.noyola@creativaconsultores.com");
            driver.FindElement(By.Id("Password")).Clear();
            driver.FindElement(By.Id("Password")).SendKeys("Admin1234!");
            driver.FindElement(By.Id("SubmitLogin")).Click();
            Thread.Sleep(5000);
            Assert.AreEqual("You logged in successfully.", driver.FindElement(By.XPath("//body/div[2]/div")).Text);

            driver.FindElement(By.LinkText("rafael")).Click();
            driver.FindElement(By.Id("view-link")).Click();
            try
            {
                Assert.IsTrue(IsElementPresent(By.LinkText("Organization Public")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            try
            {
                Assert.AreEqual("Organization", driver.FindElement(By.CssSelector("b")).Text);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            driver.FindElement(By.LinkText("Organization Public")).Click();
            try
            {
                Assert.IsTrue(IsElementPresent(By.LinkText("Rovelo Associates")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            driver.FindElement(By.LinkText("Rovelo Associates")).Click();
            try
            {
                Assert.AreEqual("Organization changed successfully.", driver.FindElement(By.XPath("//body/div[2]/div")).Text);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            driver.FindElement(By.XPath("(//a[contains(text(),'Clauses')])[2]")).Click();
            Thread.Sleep(4000);
            
            driver.FindElement(By.LinkText("Add New Clause")).Click();

            Thread.Sleep(4000);
            driver.FindElement(By.Id("Heading")).Clear();
            driver.FindElement(By.Id("Heading")).SendKeys("Test Agreement ClausePrivate");
            Thread.Sleep(2000);
            driver.FindElement(By.Id("CreateClauseFilename")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//div[@class='panel-body']/fieldset/div/div/div[5]")).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.Id("ContractTaxonomyButton")).Click();
            Thread.Sleep(4500);
            //driver.FindElement(By.CssSelector("#62 > i.jstree-icon.jstree-ocl")).Click();
            //Thread.Sleep(2000);
            //driver.FindElement(By.CssSelector("#63 > i.jstree-icon.jstree-ocl")).Click();
            //Thread.Sleep(2000);
            //driver.FindElement(By.Id("64_anchor")).Click();
            //Thread.Sleep(2000);
            driver.FindElement(By.XPath("//li[@id='62']/i")).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.XPath("//li[@id='63']/i")).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.Id("64_anchor")).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.XPath("//div[4]/div[2]/button")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.Id("ClauseTaxonomyButton")).Click();
            Thread.Sleep(4500);
            //driver.FindElement(By.CssSelector("#307 > i.jstree-icon.jstree-ocl")).Click();
            //Thread.Sleep(2000);
            //driver.FindElement(By.CssSelector("#308 > i.jstree-icon.jstree-ocl")).Click();
            //Thread.Sleep(2000);
            //driver.FindElement(By.XPath("//a[@id='309_anchor']/i")).Click();
            //Thread.Sleep(2000);
            driver.FindElement(By.XPath("//li[@id='307']/i")).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.XPath("//li[@id='308']/i")).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.Id("309_anchor")).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.XPath("//div[4]/div[2]/button")).Click();
            Thread.Sleep(2000);
            //Console.WriteLine("Clause taxonomy choosen");

            //driver.FindElement(By.LinkText("Standard *")).Click();
            Thread.Sleep(6000);///////////////////////////////////INSERTING IN DESCRIPTION 
            Console.WriteLine("Switching to Description frame...");
            try
            {
                driver.SwitchTo().Frame("Description_ifr");
                Console.Write("Switch to Description frame successful");
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }

            IWebElement body = driver.FindElement(By.CssSelector("#tinymce"));

            body.Clear();
            Thread.Sleep(2000);
            try
            {
                body.SendKeys("This Executive Employment Agreement");
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            //driver.FindElement(By.LinkText("Standard *")).Click();
            Console.WriteLine("Switching to Default Content...");
            Thread.Sleep(3000);
            try
            {
                driver.SwitchTo().DefaultContent();
                Console.Write("Switching to default page");
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            driver.FindElement(By.LinkText("Standard *")).Click();//INSERTING IN STANDANDARD CLAUSE
            try
            {
                driver.SwitchTo().Frame("StandardClause_ifr");
                Console.Write("Switch to Standard Clause frame successful");
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            IWebElement body2 = driver.FindElement(By.CssSelector("#tinymce"));

            body2.Clear();
            Thread.Sleep(2000);
            try
            {
                body2.SendKeys("1.1 \"Affiliate\":");
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            Console.WriteLine("Switching to Default Content...");//SWITCHING TO DEFAULT CONTENT
            Thread.Sleep(3000);
            try
            {
                driver.SwitchTo().DefaultContent();
                Console.Write("Switching to default page");
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            driver.FindElement(By.Id("ClauseCaption")).Clear();
            driver.FindElement(By.Id("ClauseCaption")).SendKeys("Standard");//INSERTING CAPTION FOR STANDARD
            driver.FindElement(By.XPath("//a[@id='AddClauseAlt']/i")).Click();// INSERTING IN CLAUSE STANDARD ALTERNATIVE FOR STANDARD
            try
            {
                driver.SwitchTo().Frame("ClauseAltContent1_ifr");
                Console.Write("Switch to Alt Clause frame successful");
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            IWebElement body3 = driver.FindElement(By.CssSelector("#tinymce"));

            body3.Clear();
            Thread.Sleep(2000);
            try
            {
                body3.SendKeys("1.1 Affiliate definition");
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }                                           /////END OF THE REQUIRED FIELDS OF FORM  
            //driver.FindElement(By.LinkText("Alt 1")).Click();
            //driver.FindElement(By.LinkText("Standard *")).Click();
            Console.WriteLine("Switching to Default Content...");///SWITCHING TO DEFAULT CONTENT
            Thread.Sleep(3000);
            try
            {
                driver.SwitchTo().DefaultContent();
                Console.Write("Switching to default page");
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            driver.FindElement(By.Id("ClausePrimaryButton")).Click();
            Thread.Sleep(6000);
            try
            {
                Assert.AreEqual("Clause added successfully.", driver.FindElement(By.XPath("//body/div[2]/div")).Text);
                Console.WriteLine("Clause added successfully.");
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            Thread.Sleep(6000);
            //Console.WriteLine("Pressing button Draft- Entering Draft Mode");
            driver.FindElement(By.CssSelector("span.button-status")).Click();///////// entering draft mode
            driver.FindElement(By.LinkText("Draft")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.Id("ContractTaxonomyButton")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.CssSelector("i.jstree-icon.jstree-ocl")).Click();
            driver.FindElement(By.Id("5_anchor")).Click();
            Thread.Sleep(1000);
            //driver.FindElement(By.XPath("//li[@id='1']/i")).Click();
            //Thread.Sleep(25000);
            //driver.FindElement(By.Id("5_anchor")).Click();
            //Thread.Sleep(5000);
            driver.FindElement(By.XPath("//div[4]/div[2]/button")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.Id("ClauseTaxonomyButton")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//div[2]/button[2]")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.Id("ClauseCaption")).Clear();
            driver.FindElement(By.Id("ClauseCaption")).SendKeys("Executive's Standard");
            Thread.Sleep(1000);
            driver.FindElement(By.LinkText("Alt 1")).Click();
            driver.FindElement(By.Id("ClauseAltTab1")).Clear();
            driver.FindElement(By.Id("ClauseAltTab1")).SendKeys("Affiliates");
            Thread.Sleep(1000);
            driver.FindElement(By.CssSelector("span.button-status")).Click();/////////////SAVE DRAFT
            Assert.AreEqual("Draft Clause edited successfully.", driver.FindElement(By.XPath("//body/div[2]/div")).Text);
            Thread.Sleep(1000);
            driver.FindElement(By.LinkText("Draft")).Click();
            //driver.FindElement(By.CssSelector("#ClausePrimaryButton > span.button-status")).Click();
            driver.FindElement(By.CssSelector("#ClausePrimaryButton > btn btn-sm btn - success")).Click(); ///////PUBLISH DRAFT
            Thread.Sleep(3000);
            try
            {
                Assert.AreEqual("Draft Clause approved and published successfully.", driver.FindElement(By.XPath("/body/div[2]/div")).Text);
                Console.WriteLine("Draft Clause approved and published successfully.");
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            driver.FindElement(By.Id("DeleteClauseButton")).Click();//driver.FindElement(By.CssSelector("#ClausePrimaryButton > btn btn-sm btn-danger")).Click();
            driver.FindElement(By.XPath("//div[4]/div[2]/button")).Click();
            Thread.Sleep(3000);
            Assert.AreEqual("Original Clause deleted successfully.", driver.FindElement(By.XPath("//body/div[2]/div")).Text);

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
