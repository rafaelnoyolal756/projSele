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
            Thread.Sleep(4000);
            Assert.AreEqual("You logged in successfully.", driver.FindElement(By.XPath("//body/div[2]/div")).Text);
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
            try
            {
                Assert.AreEqual("[\n {\n \"refset\": \"CS-CICTEST\",\n \"parent\": null,\n \"child\": [],\n \"data_tcg\": \"_TB9eeda4d0-28ea-4d8f-950a-3154e60f60bb\",\n \"heading\": \"Definitions TEST\",\n \"commonality\": \"43\",\n \"consistency\": \"58\",\n \"status\": \"S\",\n \"flagged\": false\n },\n {\n \"refset\": \"CS-CICTEST\",\n \"parent\": null,\n \"child\": [],\n \"data_tcg\": \"_TB0de70aa7-98a1-4d8a-80ed-b6fbb0c64eaa\",\n \"heading\": \"Definitions Of Change Of Control TEST\",\n \"commonality\": \"43\",\n \"consistency\": \"58\",\n \"status\": \"T\",\n \"flagged\": false\n },\n {\n \"refset\": \"CS-CICTEST\",\n \"parent\": null,\n \"child\": [],\n \"data_tcg\": \"_TBc061d690-6c8e-40e4-9d1f-f9fb2780c37a\",\n \"heading\": \"Term TEST\",\n \"commonality\": \"78\",\n \"consistency\": \"79\",\n \"status\": \"S\",\n \"flagged\": false\n },\n {\n \"refset\": \"CS-CICTEST\",\n \"parent\": null,\n \"child\": [],\n \"data_tcg\": \"_TBa5a1e122-7a0f-467c-be91-5d149376202c\",\n \"heading\": \"Employment TEST\",\n \"commonality\": \"29\",\n \"consistency\": \"68\",\n \"status\": \"D\",\n \"flagged\": false\n },\n {\n \"refset\": \"CS-CICTEST\",\n \"parent\": null,\n \"child\": [],\n \"data_tcg\": \"_TB975c3982-ff0a-4236-9e72-05050ef3f51f\",\n \"heading\": \"Termination Of Employment TEST\",\n \"commonality\": \"53\",\n \"consistency\": \"82\",\n \"status\": \"T\",\n \"flagged\": false\n },\n {\n \"refset\": \"CS-CICTEST\",\n \"parent\": null,\n \"child\": [],\n \"data_tcg\": \"_TB50a36f9f-9396-43f3-a2b4-8d45a3244e45\",\n \"heading\": \"Change Of Control Benefit TEST\",\n \"commonality\": \"32\",\n \"consistency\": \"55\",\n \"status\": \"S\",\n \"flagged\": false\n },\n {\n \"refset\": \"CS-CICTEST\",\n \"parent\": null,\n \"child\": [],\n \"data_tcg\": \"_tbman_ce3c6b06-ac75-4e34-82d6-8f76868729fa\",\n \"heading\": \"No Employment TEST\",\n \"commonality\": \"21\",\n \"consistency\": \"67\",\n \"status\": \"D\",\n \"flagged\": false\n },\n {\n \"refset\": \"CS-CICTEST\",\n \"parent\": null,\n \"child\": [],\n \"data_tcg\": \"_tbman_3feb58cc-d821-4e9f-828b-9795be173337\",\n \"heading\": \"No Set-Off TEST\",\n \"commonality\": \"12\",\n \"consistency\": \"97\",\n \"status\": \"U\",\n \"flagged\": false\n },\n {\n \"refset\": \"CS-CICTEST\",\n \"parent\": null,\n \"child\": [],\n \"data_tcg\": \"_TBb2970b70-2193-43a4-8692-a8d52d6d0420\",\n \"heading\": \"Confidentiality\",\n \"commonality\": \"53\",\n \"consistency\": \"83\",\n \"status\": \"T\",\n \"flagged\": false\n },\n {\n \"refset\": \"CS-CICTEST\",\n \"parent\": null,\n \"child\": [],\n \"data_tcg\": \"_tbman_e9334af5-9d61-4298-a2a6-7049aacff87e\",\n \"heading\": \"Non-Compete TEST\",\n \"commonality\": \"27\",\n \"consistency\": \"76\",\n \"status\": \"T\",\n \"flagged\": false\n },\n {\n \"refset\": \"CS-CICTEST\",\n \"parent\": null,\n \"child\": [],\n \"data_tcg\": \"_TB079a36ee-eb1f-45af-9aa1-d96d6f1a6baf\",\n \"heading\": \"Non-Solicitation TEST\",\n \"commonality\": \"19\",\n \"consistency\": \"88\",\n \"status\": \"T\",\n \"flagged\": false\n },\n {\n \"refset\": \"CS-CICTEST\",\n \"parent\": null,\n \"child\": [],\n \"data_tcg\": \"_TBe96d3ab9-e19d-43dc-834e-e75cb4290687\",\n \"heading\": \"Code Section 409A TEST\",\n \"commonality\": \"25\",\n \"consistency\": \"82\",\n \"status\": \"T\",\n \"flagged\": false\n },\n {\n \"refset\": \"CS-CICTEST\",\n \"parent\": null,\n \"child\": [],\n \"data_tcg\": \"_TB732f24ed-7c2c-4f6d-a07d-81b88457d2d2\",\n \"heading\": \"Indemnification TEST\",\n \"commonality\": \"10\",\n \"consistency\": \"89\",\n \"status\": \"U\",\n \"flagged\": false\n },\n {\n \"refset\": \"CS-CICTEST\",\n \"parent\": null,\n \"child\": [\n {\n \"refset\": \"CS-CICTEST\",\n \"parent\": null,\n \"child\": [],\n \"data_tcg\": \"_TBf48ae768-d885-4e03-8690-d11c409d19aa\",\n \"heading\": \"Notices TEST\",\n \"commonality\": \"82\",\n \"consistency\": \"89\",\n \"status\": \"S\",\n \"flagged\": false\n },\n {\n \"refset\": \"CS-CICTEST\",\n \"parent\": null,\n \"child\": [],\n \"data_tcg\": \"_TB79771e53-bb2d-4132-a7c7-01fbbb315738\",\n \"heading\": \"Binding Agreement TEST\",\n \"commonality\": \"53\",\n \"consistency\": \"84\",\n \"status\": \"T\",\n \"flagged\": false\n },\n {\n \"refset\": \"CS-CICTEST\",\n \"parent\": null,\n \"child\": [\n {\n \"refset\": \"CS-CICTEST\",\n \"parent\": null,\n \"child\": [],\n \"data_tcg\": \"_TB244b01b7-db86-4089-9560-4f9aed87463e\",\n \"heading\": \"Agreement Personal Executive Without Prior\",\n \"commonality\": \"17\",\n \"consistency\": \"94\",\n \"status\": \"T\",\n \"flagged\": false\n },\n {\n \"refset\": \"CS-CICTEST\",\n \"parent\": null,\n \"child\": [],\n \"data_tcg\": \"_TB2effd77c-8f98-4c1c-9ec2-a49aef2dc419\",\n \"heading\": \"Agreement Inure Benefit Binding Upon\",\n \"commonality\": \"21\",\n \"consistency\": \"93\",\n \"status\": \"T\",\n \"flagged\": false\n },\n {\n \"refset\": \"CS-CICTEST\",\n \"parent\": null,\n \"child\": [],\n \"data_tcg\": \"_TBb17af58d-cbb7-4d85-a51c-c915f19eca34\",\n \"heading\": \"Company Require Successor Whether Direct\",\n \"commonality\": \"12\",\n \"consistency\": \"89\",\n \"status\": \"U\",\n \"flagged\": false\n }\n ],\n \"data_tcg\": \"_TBfe79bec3-3923-46a2-9500-22b2d6ea6333\",\n \"heading\": \"Successors TEST\",\n \"commonality\": \"63\",\n \"consistency\": \"76\",\n \"status\": \"S\",\n \"flagged\": false\n },\n {\n \"refset\": \"CS-CICTEST\",\n \"parent\": null,\n \"child\": [],\n \"data_tcg\": \"_TB5cb721a2-53bc-4cb3-8219-4ae50d1c7a0b\",\n \"heading\": \"Assignment TEST\",\n \"commonality\": \"38\",\n \"consistency\": \"71\",\n \"status\": \"D\",\n \"flagged\": false\n },\n {\n \"refset\": \"CS-CICTEST\",\n \"parent\": null,\n \"child\": [],\n \"data_tcg\": \"_TB906dde33-1269-4465-b1d6-71f5e39bb367\",\n \"heading\": \"Settlement Of Disputes TEST\",\n \"commonality\": \"44\",\n \"consistency\": \"83\",\n \"status\": \"T\",\n \"flagged\": false\n },\n {\n \"refset\": \"CS-CICTEST\",\n \"parent\": null,\n \"child\": [],\n \"data_tcg\": \"_TB94fd49d8-2f25-4aab-a4bf-e7280d0517f4\",\n \"heading\": \"Governing Law TEST\",\n \"commonality\": \"72\",\n \"consistency\": \"79\",\n \"status\": \"S\",\n \"flagged\": false\n },\n {\n \"refset\": \"CS-CICTEST\",\n \"parent\": null,\n \"child\": [],\n \"data_tcg\": \"_TB4447ac81-fcb9-4cbc-a37b-0ed99235d4ea\",\n \"heading\": \"Waiver TEST\",\n \"commonality\": \"29\",\n \"consistency\": \"69\",\n \"status\": \"D\",\n \"flagged\": false\n },\n {\n \"refset\": \"CS-CICTEST\",\n \"parent\": null,\n \"child\": [],\n \"data_tcg\": \"_TB9185f3b2-98d9-442f-976d-f7eb82ce7f96\",\n \"heading\": \"Severability TEST\",\n \"commonality\": \"87\",\n \"consistency\": \"83\",\n \"status\": \"S\",\n \"flagged\": false\n },\n {\n \"refset\": \"CS-CICTEST\",\n \"parent\": null,\n \"child\": [],\n \"data_tcg\": \"_TB59faf51d-f66e-46e0-8594-2f4da2aec6b2\",\n \"heading\": \"No Mitigation TEST\",\n \"commonality\": \"53\",\n \"consistency\": \"83\",\n \"status\": \"T\",\n \"flagged\": false\n },\n {\n \"refset\": \"CS-CICTEST\",\n \"parent\": null,\n \"child\": [],\n \"data_tcg\": \"_TBc5cf1543-58e5-428b-81ff-8fd5d881c991\",\n \"heading\": \"Non-Exclusivity Of Rights TEST\",\n \"commonality\": \"21\",\n \"consistency\": \"94\",\n \"status\": \"T\",\n \"flagged\": false\n },\n {\n \"refset\": \"CS-CICTEST\",\n \"parent\": null,\n \"child\": [],\n \"data_tcg\": \"_TB464a3897-4cde-42a5-a625-f167f87be4a3\",\n \"heading\": \"No Attachment TEST\",\n \"commonality\": \"10\",\n \"consistency\": \"97\",\n \"status\": \"U\",\n \"flagged\": false\n },\n {\n \"refset\": \"CS-CICTEST\",\n \"parent\": null,\n \"child\": [],\n \"data_tcg\": \"_TB1acd06a6-87ef-4192-8b47-d6e4afff7454\",\n \"heading\": \"Headings TEST\",\n \"commonality\": \"17\",\n \"consistency\": \"92\",\n \"status\": \"T\",\n \"flagged\": false\n },\n {\n \"refset\": \"CS-CICTEST\",\n \"parent\": null,\n \"child\": [],\n \"data_tcg\": \"_TBcf9235de-cc18-4359-b99d-e8549c6e1bb4\",\n \"heading\": \"Legal Fees And Expenses TEST\",\n \"commonality\": \"74\",\n \"consistency\": \"79\",\n \"status\": \"S\",\n \"flagged\": false\n },\n {\n \"refset\": \"CS-CICTEST\",\n \"parent\": null,\n \"child\": [],\n \"data_tcg\": \"_TBac876a6d-6f6b-49e8-8d00-795dcd626df6\",\n \"heading\": \"Withholding TEST\",\n \"commonality\": \"51\",\n \"consistency\": \"90\",\n \"status\": \"T\",\n \"flagged\": false\n },\n {\n \"refset\": \"CS-CICTEST\",\n \"parent\": null,\n \"child\": [],\n \"data_tcg\": \"_TB81074d5c-7d58-4830-a002-02c636c30657\",\n \"heading\": \"Entire Agreement TEST\",\n \"commonality\": \"68\",\n \"consistency\": \"73\",\n \"status\": \"S\",\n \"flagged\": false\n },\n {\n \"refset\": \"CS-CICTEST\",\n \"parent\": null,\n \"child\": [],\n \"data_tcg\": \"_TB6d3edc90-bdc3-47cb-86c7-5c98d6f6fcc1\",\n \"heading\": \"Counterparts TEST\",\n \"commonality\": \"38\",\n \"consistency\": \"85\",\n \"status\": \"T\",\n \"flagged\": false\n },\n {\n \"refset\": \"CS-CICTEST\",\n \"parent\": null,\n \"child\": [],\n \"data_tcg\": \"_TBc9a0ffbe-dc27-4ba6-8eab-bfdf655d1c66\",\n \"heading\": \"Amendments TEST\",\n \"commonality\": \"46\",\n \"consistency\": \"81\",\n \"status\": \"T\",\n \"flagged\": false\n }\n ],\n \"data_tcg\": \"_TBf56e19fe-7aa8-4906-b498-a575ca236eb2\",\n \"heading\": \"Miscellaneous TEST\",\n \"commonality\": \"59\",\n \"consistency\": \"73\",\n \"status\": \"T\",\n \"flagged\": false\n }\n]", driver.FindElement(By.CssSelector("pre.file-preview-text")).Text);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            Thread.Sleep(3000);
            //driver.FindElement(By.XPath("//div[4]/div[2]/button[2]")).Click();
            driver.FindElement(By.CssSelector("#SubmitChecklist > btn btn-sm btn-primary")).Click();
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
