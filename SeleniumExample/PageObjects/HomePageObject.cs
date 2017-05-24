using System;
using System.Security.Permissions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SeleniumExample.Extensions;

namespace SeleniumExample.PageObjects
{
    public class HomePageObject
    {
        private readonly IWebDriver _driver;

        private readonly Uri _url = new Uri("http://asos.com/men");
         
        public HomePageObject(IWebDriver driver)
        {
            _driver = driver;
        }

        private readonly By _txtSearch = By.ClassName("search-box");

        private readonly By _btnSearch = By.ClassName("go");

        public void Open()
        {
            _driver.Navigate().GoToUrl(_url);
        }

        public void SearchByText(string searchTerm)
        {
            var search =_driver.WaitForCondition(x => x.FindElement(_txtSearch));

            search.SendKeys(searchTerm);

            var searchButton = _driver.WaitForCondition(x => x.FindElement(_btnSearch));

            searchButton.Click();
        }

    }
}