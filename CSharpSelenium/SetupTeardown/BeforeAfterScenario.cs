using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace CSharpSelenium.SetupTeardown
{
    [Binding]
    public class BeforeAfterScenario
    {
        IWebDriver webDriver;
        private readonly IObjectContainer objectContainer;
        public BeforeAfterScenario(IObjectContainer objectContainer)
        {
            //this.webDriver = new FirefoxDriver();
            this.objectContainer = objectContainer;
        }

        [BeforeScenario(Order = 0)]
        public void BeforeScenario()
        {
            webDriver = new FirefoxDriver();
            //webDriver = new ChromeDriver();
            objectContainer.RegisterInstanceAs<IWebDriver>(webDriver);
        }

        [AfterScenario(Order = 0)]
        public void AfterScenario()
        {
            webDriver.Quit();
        }
    }
}
