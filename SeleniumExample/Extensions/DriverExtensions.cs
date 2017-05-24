using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SeleniumExample.Extensions
{
    public static class DriverExtensions
    {
        public static IWebElement WaitForCondition(this IWebDriver driver, Func<IWebDriver, IWebElement> func)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            return wait.Until(func);
        }
    }
}
