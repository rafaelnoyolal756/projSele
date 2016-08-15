using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using NUnit.Framework;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace se_builder {

    [TestClass]
    
    public class CopyCancelClauseCSharp {[TestMethod]
    static void Main(string[] args) {
      IWebDriver wd = new RemoteWebDriver(DesiredCapabilities.Chrome());
      try {
        var wait = new WebDriverWait(wd, TimeSpan.FromSeconds(60));
        wd.Navigate().GoToUrl("http://54.173.64.156/CS/");
        wd.FindElement(By.LinkText("Log In")).Click();
        wd.FindElement(By.Id("UserName")).Click();
        wd.FindElement(By.Id("UserName")).Clear();
        wd.FindElement(By.Id("UserName")).SendKeys("rafael.noyola@creativaconsultores.com");
        wd.FindElement(By.Id("Password")).Click();
        wd.FindElement(By.Id("Password")).Clear();
        wd.FindElement(By.Id("Password")).SendKeys("Admin1234!");
        wd.FindElement(By.Id("SubmitLogin")).Click();
        wd.FindElement(By.XPath("//div[2]/div")).Click();
        wd.FindElement(By.LinkText("rafael")).Click();
        wd.FindElement(By.Id("view-link")).Click();
        wd.FindElement(By.XPath("//div[@class='body-content']//a[.=' Clauses']")).Click();
        if (!wd.FindElement(By.XPath("//select[@id='dataTableClausesAll-Status-select-search']//option[3]")).Selected) {
            wd.FindElement(By.XPath("//select[@id='dataTableClausesAll-Status-select-search']//option[3]")).Click();
        }
        wd.FindElement(By.LinkText("Acceptance Copy 2")).Click();
        wd.FindElement(By.LinkText("Copy")).Click();
        wd.FindElement(By.Id("Heading")).Click();
        wd.FindElement(By.Id("Heading")).SendKeys("\\9");
        wd.FindElement(By.Id("ContractTaxonomyButton")).Click();
        wd.FindElement(By.XPath("//li[@id='24']/i")).Click();
        wd.FindElement(By.Id("25_anchor")).Click();
        wd.FindElement(By.XPath("//div[@class='ajs-footer']//button[.='Ok']")).Click();
        wd.FindElement(By.LinkText("Cancel")).Click();
        wd.FindElement(By.LinkText("rafael")).Click();
        wd.FindElement(By.LinkText("Log Out")).Click();
      } finally { wd.Quit(); }
    }
    
    public static bool isAlertPresent(IWebDriver wd) {
        try {
            wd.SwitchTo().Alert();
            return true;
        } catch (NoAlertPresentException e) {
            return false;
        }
    }
  }
}
