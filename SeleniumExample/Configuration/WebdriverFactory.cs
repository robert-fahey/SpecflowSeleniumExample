using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;

namespace SeleniumExample.Configuration
{
    public enum DriverEnum
    {
        Chrome,
        InternetExplorer,
        HtmlUnitWithJavaScript,
        PhantomJS
    }
    public class WebDriverFactory
    {
        public static IWebDriver Create()
        {
            return new ChromeDriver();
        }

        public static RemoteWebDriver Create(
            int seleniumServerPort,
            string testServerName,
            string version,
            string platform,
            DriverEnum driverType)
        {
            var ip = new Uri("http://" + testServerName + ":" + seleniumServerPort + "/wd/hub");

            var capabilities = GetDesiredCapabilities(driverType);

            capabilities.SetCapability(CapabilityType.Version, version);
            capabilities.SetCapability(CapabilityType.Platform, platform);

            var driver = new RemoteWebDriver(ip, capabilities);

            return driver;
        }


        private static DesiredCapabilities GetDesiredCapabilities(DriverEnum driverType)
        {
            switch (driverType)
            {
                case DriverEnum.Chrome:
                    return DesiredCapabilities.Chrome();
                case DriverEnum.InternetExplorer:
                    return DesiredCapabilities.InternetExplorer();
                case DriverEnum.HtmlUnitWithJavaScript:
                    return DesiredCapabilities.HtmlUnitWithJavaScript();
                case DriverEnum.PhantomJS:
                    return DesiredCapabilities.PhantomJS();
                default:
                    throw new Exception("Unknown driver type");

            }
        }
    }
}
