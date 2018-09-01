using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using CSharpSelenium.Pages;
using NUnit.Framework;

namespace CSharpSelenium.Steps
{
    [Binding]
    public class CSharpSeleniumProjectSteps
    {
        IWebDriver _driver;
        LogInGmailPage login_gmail_page;
        public CSharpSeleniumProjectSteps(IWebDriver webDriver)
        {
            this._driver = webDriver;
            this.login_gmail_page = new LogInGmailPage(this._driver);
        }

        [Given(@"I am on gmail home page")]
        public void GivenIAmOnGmailHomePage()
        {
            _driver.Url = "https://www.gmail.com";
            //ScenarioContext.Current.Pending();
        }
        
        [When(@"I input valid username and password")]
        public void WhenIInputValidUsernameAndPassword(Table table)
        {
            dynamic user_info = table.CreateDynamicInstance();
            login_gmail_page.input_username_passwd(user_info.username, user_info.password);
            //ScenarioContext.Current.Pending();
        }
        
        [Then(@"I should see gmail inbox")]
        public void ThenIShouldSeeGmailInbox()
        {
            //Console.WriteLine("=======================");
            //Console.WriteLine(_driver.title);
            //Console.WriteLine("=======================");
            Assert.IsTrue(login_gmail_page.verify_title("Inbox"));
            //ScenarioContext.Current.Pending();
        }
    }
}
