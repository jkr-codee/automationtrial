using System;
using System.Threading;
using ERM.AutomationTrial.Infrastructure.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;

namespace ERM.AutomationTrial.Infrastructure.Browser
{
    /// <summary>
    /// Browser class for creating an instance of a particular web driver based on the config value from application configuration file.
    /// </summary>
    public class Browser
    {
        private BrowserType _browserType;
        public Browser(BrowserType browserType)
        {
            WebDriver = GetWebDriver(browserType);
        }

        /// <summary>
        /// Returns the web driver based on the config settings
        /// Also initialises the driver
        /// </summary>
        /// <param name="browserType">Browser type enum based on the config value</param>
        /// <returns>WebDriver of appropriate browser</returns>
        private RemoteWebDriver GetWebDriver(BrowserType browserType)
        {
            RemoteWebDriver webDriver = null;
            switch (browserType)
            {
                case BrowserType.Chrome:
                    webDriver = new ChromeDriver();
                    break;
                case BrowserType.FireFox:
                    webDriver = new FirefoxDriver();
                    break;
                case BrowserType.InternetExplorer:
                    webDriver = new InternetExplorerDriver();
                    break;
            }

            webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            webDriver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(10);
            webDriver.Manage().Window.Maximize();
            _browserType = browserType;
            return webDriver;
        }


        /// <summary>
        /// Returns the instance of a driver if a new driver is required
        /// </summary>
        /// <param name="browserType">Browser type enum based on the config value</param>
        /// <returns>WebDriver of appropriate browser</returns>
        public static Browser GetInstance(BrowserType browserType)
        {
            return new Browser(browserType);
        }


        /// <summary>
        /// Navigate to appropriate URL in the browser
        /// </summary>
        /// <param name="url">Url to be navigated to</param>
        public void NavigateToUrl(string url)
        {
            WebDriver.Navigate().GoToUrl(url);
        }

        /// <summary>
        /// Extension method to find element from the page using partial ID selector
        /// </summary>
        /// <param name="partialCssSelector">Partial name of the element id</param>
        /// <returns>Matching web elements of the partial id's</returns>
        public IWebElement FindElementByPartialId(string partialCssSelector)
        {
            return WebDriver.FindElementByCssSelector($"[id*= {partialCssSelector}]");
        }

        /// <summary>
        /// Extension method to find element from the page using partial CSS selector
        /// </summary>
        /// <param name="partialCssSelector">Partial name of the CSS class</param>
        /// <returns>Matching web elements of the CSS class</returns>
        public IWebElement FindElementByPartialClass(string partialCssSelector)
        {
            return WebDriver.FindElementByCssSelector($"[class*={partialCssSelector}]");
        }

        public RemoteWebDriver WebDriver { get; set; }
    }
}
