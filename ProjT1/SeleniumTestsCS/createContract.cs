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
    public class CreateContract
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
        public void TheCreateContractTest()
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
            driver.FindElement(By.LinkText("rafael")).Click();
            driver.FindElement(By.Id("view-link")).Click();
            driver.FindElement(By.XPath("(//a[contains(text(),'Contracts')])[2]")).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.XPath("(//button[@type='button'])[4]")).Click();
            driver.FindElement(By.LinkText("Add New Contract")).Click();
            Thread.Sleep(5000);
            // ERROR: Caught exception [ERROR: Unsupported command [selectFrame | contract | ]]
            //driver.FindElement(By.CssSelector("ul.children > li.child > ul.children > li.child > ul.children > li.child > ul.children > li.child > ul.children > li.child > ul.children > li.child > ul.children > li.child > ul.children > li.child > ul.children > li.child > ul.children > li.child > ul.children > li.child > ul.children > li.child > ul.children > li.child > ul.children > li.child > ul.children > li.child > ul.children > li.child > div.tag-line > span.theme-twisty.expander")).Click();
            // ERROR: Caught exception [unknown command []]

            driver.FindElement(By.CssSelector("p.L1")).Click();
            driver.FindElement(By.CssSelector("p.L1")).Clear();
            driver.FindElement(By.CssSelector("p.L1")).SendKeys("This executive employment Agreement");
            //driver.FindElement(By.XPath("//div[@id='mceu_38']/button")).Click();
            //driver.FindElement(By.Id("mceu_74-body")).Click();
            //driver.FindElement(By.XPath("//div[@id='mceu_76']//button[.='Cancel']")).Click();
            //driver.FindElement(By.CssSelector("h2.sub-header")).Click();
            //driver.FindElement(By.CssSelector("p.L3")).Click();
            //driver.FindElement(By.CssSelector("p.L2")).Click();
            //driver.FindElement(By.CssSelector("p.L2")).SendKeys("This executive employment Agreement");
            //driver.FindElement(By.XPath("//div[@id='mceu_38']/button")).Click();////////in new window
            //driver.FindElement(By.XPath("//div[@id='mceu_38']/button")).Click();
            //driver.FindElement(By.XPath("//div[@id='mceu_120']//button[.='Cancel']")).Click();/////close window
            //driver.FindElement(By.XPath("//div[@id='mceu_120']//button[.='Cancel']")).Click();
            //driver.FindElement(By.Id("ContractPrimaryButton")).Click();
            //driver.FindElement(By.Id("ContractPrimaryButton")).Click();
            //driver.FindElement(By.Id("ContractSecondaryButton")).Click();
            //driver.FindElement(By.Id("ContractSecondaryButton")).Click();
            driver.FindElement(By.Id("menu-toggle")).Click();
            //driver.FindElement(By.Id("menu-toggle")).Click();
            //driver.FindElement(By.Id("Title")).Click();
            driver.FindElement(By.Id("Title")).Click();
            driver.FindElement(By.Id("Title")).Clear();
            driver.FindElement(By.Id("Title")).SendKeys("ContractAgreement");
            driver.FindElement(By.Id("CreateContractFilename")).Click();
            //driver.FindElement(By.Id("CreateContractFilename")).Click();
            driver.FindElement(By.XPath("//form[@id='ContractForm']/div[1]/div[2]/div")).Click();//checklist
            //driver.FindElement(By.XPath("//form[@id='ContractForm']/div[1]/div[2]/div")).Click();
            driver.FindElement(By.Id("TaxonomyButton")).Click();
            //driver.FindElement(By.Id("TaxonomyButton")).Click();
            driver.FindElement(By.CssSelector("i.jstree-icon.jstree-ocl")).Click();
            driver.FindElement(By.CssSelector("i.jstree-icon.jstree-ocl")).Click();
            driver.FindElement(By.Id("4_anchor")).Click();
            //driver.FindElement(By.Id("4_anchor")).Click();
            driver.FindElement(By.XPath("//div[@class='ajs-footer']//button[.='Ok']")).Click();
            //driver.FindElement(By.XPath("//div[@class='ajs-footer']//button[.='Ok']")).Click();
            driver.FindElement(By.LinkText("Select an Option")).Click();
            driver.FindElement(By.LinkText("Select an Option")).Click();
            driver.FindElement(By.CssSelector("li.active-result.result-selected")).Click();
            //driver.FindElement(By.CssSelector("li.active-result.result-selected")).Click();
            driver.FindElement(By.XPath("//div[@class='chosen-search']/input")).Click();
            driver.FindElement(By.XPath("//div[@class='chosen-search']/input")).Clear();
            driver.FindElement(By.XPath("//div[@class='chosen-search']/input")).SendKeys("dd");
            driver.FindElement(By.XPath("//span[@class='btn-group']/button")).Click();
            driver.FindElement(By.XPath("//span[@class='btn-group']/button")).Click();
            driver.FindElement(By.CssSelector("h3")).Click();
            driver.FindElement(By.CssSelector("h3")).Click();
            driver.FindElement(By.XPath("//span[@class='btn-group']/button")).Click();
            //driver.FindElement(By.XPath("//span[@class='btn-group']/button")).Click();
            driver.FindElement(By.Id("contract-content")).Click();
            //driver.FindElement(By.Id("contract-content")).Click();
            driver.FindElement(By.Id("ContractPrimaryButton")).Click();
            //driver.FindElement(By.Id("ContractPrimaryButton")).Click();
            driver.FindElement(By.XPath("//div[2]/div")).Click();
            try
            {
                Assert.AreEqual("Contract added successfully.", driver.FindElement(By.CssSelector("div.ajs-message.ajs-success")).Text);
                Console.WriteLine("Contract added successfully.");
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
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
