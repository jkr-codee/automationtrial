using ERM.AutomationTrial.Infrastructure.Browser;
using ERM.AutomationTrial.Infrastructure.Utils;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace ERM.AutomationTrial.Pages
{
    /// <summary>
    /// Base class representation of web page
    /// This class defines the standard methods required for each page during testing
    /// </summary>
    public class BasePage
    {
        
        protected Browser _browser;

        public BasePage()
        {
            _browser = Browser.GetInstance(BrowserType);
        }

        /// <summary>
        /// Get the URL of the site and navigate to home page
        /// </summary>
        public void GotoHomePage()
        {
            _browser.NavigateToUrl(ConfigUtils.GetApplicationUrl());
        }

        /// <summary>
        /// Calls webdrivers close method to close the browser instance
        /// </summary>
        public void CloseBrowser()
        {
            _browser.WebDriver.Close();
        }

        /// <summary>
        /// Create a new instance of the browser
        /// </summary>
        public void NewBrowser()
        {
            _browser = Browser.GetInstance(BrowserType);
        }

        private BrowserType BrowserType
        {
            get
            {
                return ConfigUtils.GetBrowserType();
            }
        }


        /// <summary>
        /// Find the given text field name using partial id search and
        /// assign the given value for the text field
        /// </summary>
        /// <param name="formName">Form name or container name for the element</param>
        /// <param name="fieldName">Partial name of the text field where the value should be set</param>
        /// <param name="value">Value for the text field</param>
        protected void EnterFieldValue(string formName, string fieldName, string value)
        {
            var webElement = _browser.FindElementByPartialId($"{formName}{fieldName}");
            Assert.IsNotNull(webElement);
            webElement.SendKeys(value);
        }

        ~BasePage()=> _browser.WebDriver.Quit();
    }
}