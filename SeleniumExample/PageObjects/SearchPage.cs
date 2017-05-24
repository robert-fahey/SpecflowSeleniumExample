using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using SeleniumExample.Extensions;

namespace SeleniumExample.PageObjects
{
    public class SearchPage
	{
        public SearchPage(IWebDriver driver)
        {
            _driver = driver;
        }

        private readonly By _searchTerm = By.ClassName("search-term");

        private IWebDriver _driver;

        public string GetSearchTerm()
        {
            return _driver.WaitForCondition(x => x.FindElement(_searchTerm)).Text;
        }
    }
}


