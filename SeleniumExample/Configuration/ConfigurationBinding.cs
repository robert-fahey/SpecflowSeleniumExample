using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoDi;
using OpenQA.Selenium;
using SeleniumExample.PageObjects;
using TechTalk.SpecFlow;

namespace SeleniumExample.Configuration
{
    [Binding]
    public class ConfigurationBinding
    {
        private IObjectContainer _objectContainer;

        public ConfigurationBinding(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
        }


        [BeforeScenario(Order = 0)]
        public void InitializeWebDriver()
        {
            var driver = WebDriverFactory.Create();

            _objectContainer.RegisterInstanceAs<IWebDriver>(driver);
        }

        [BeforeScenario(Order = 1)]
        public void InitializePageObjects()
        {
            _objectContainer.RegisterInstanceAs<HomePageObject>(new HomePageObject(_objectContainer.Resolve<IWebDriver>()));
            _objectContainer.RegisterInstanceAs<SearchPage>(new SearchPage(_objectContainer.Resolve<IWebDriver>()));
        }

        [AfterScenario]
        public void DisposeWebDriver()
        {
            var driver = 
            _objectContainer.Resolve<IWebDriver>();

            driver.Quit();
        }
    }
}
