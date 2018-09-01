using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSelenium.Pages
{
    public class BasePage
    {
        public IWebDriver _driver;
        public WebDriverWait driver_wait;

        public BasePage(IWebDriver webDriver)
        {
            this._driver = webDriver;
            
        }

        public bool verify_title(string strTitle)
        {
            return _driver.Title.Contains(strTitle);
        }

        public void wait_elem(string locate_type, string elem_locator, int wait_time)
        {
            driver_wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(wait_time));
            switch (locate_type)
            {
                case "CssSelector":
                    driver_wait.Until(_driver => _driver.FindElement(By.CssSelector(elem_locator)));
                    break;
                case "XPath":
                    driver_wait.Until(_driver => _driver.FindElement(By.XPath(elem_locator)));
                    break;
                default:
                    Console.WriteLine("Error: Cannot match locate_type.");
                    break;
            }
        }
    }
}
