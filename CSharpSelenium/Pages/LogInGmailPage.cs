using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSelenium.Pages
{
    public class LogInGmailPage  : BasePage
    {
        public LogInGmailPage(IWebDriver webDriver) : base(webDriver) { }

        IWebElement username_text => _driver.FindElement(By.CssSelector("#identifierId"));
        IWebElement next_btn => _driver.FindElement(By.CssSelector("#identifierNext > content:nth-child(3)"));
        IWebElement passwd_text => _driver.FindElement(By.CssSelector("#password > div:nth-child(1) > div:nth-child(1) > div:nth-child(1) > input:nth-child(1)"));
        IWebElement login_btn => _driver.FindElement(By.CssSelector("#passwordNext > content:nth-child(3) > span:nth-child(1)"));
 
        public void input_username_passwd(string username, string passwd)
        {
            // Input username
            username_text.Clear();
            username_text.SendKeys(username);
            
            //waitNextElem.Until(_driver => _driver.FindElement(By.CssSelector("#identifierNext > content:nth-child(3)")));
            // Wait for presence of "Next" button and click
            wait_elem("CssSelector", "#identifierNext > content:nth-child(3)", 10);
            next_btn.Click();
            
            //waitNextElem.Until(_driver => _driver.FindElement(By.CssSelector("#password > div:nth-child(1) > div:nth-child(1) > div:nth-child(1) > input:nth-child(1)")));
            // Wait for presence of "Password" field and input password
            wait_elem("CssSelector", "#password > div:nth-child(1) > div:nth-child(1) > div:nth-child(1) > input:nth-child(1)", 10);
            passwd_text.Clear();
            passwd_text.SendKeys(passwd);
            
            // Wait for class "ANuIbb IdAqtf" to be invisible the click login button
            WebDriverWait waitNextElem = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            waitNextElem.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//div[@class='ANuIbb IdAqtf']")));
            login_btn.Click();
        }
    }
}
