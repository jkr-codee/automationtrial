using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ERM.AutomationTrial.Common;
using ERM.AutomationTrial.Infrastructure;
using ERM.AutomationTrial.Infrastructure.Browser;
using ERM.AutomationTrial.Infrastructure.Utils;
using NUnit.Framework;

namespace ERM.AutomationTrial.Pages
{
    public class LoginPage: BasePage
    {
        protected static readonly log4net.ILog _log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private readonly string _loginUserContainerName = Constants.WebFormContainerNames.Login;
        public void GotoLoginPage()
        {
            Stopwatch watch = Stopwatch.StartNew();
            _log.Info($"Loading the nop-commerce page. Start time {DateTime.Now}");
            GotoHomePage();
            var loginElement = _browser.WebDriver.FindElementByClassName("ico-login");
            loginElement.Click();
            _log.Info($"Time taken to load login page {watch.Elapsed.Seconds} seconds.");
        }

        public void EnterUserName(string userName)
        {
            _log.Info($"Entering username in the login page");
            var userNameField = _browser.FindElementByPartialId($"{_loginUserContainerName}UserName");
            Assert.IsNotNull(userNameField);
            userNameField.SendKeys(userName);
        }

        public void EnterPassword(string password)
        {
            _log.Info($"Entering password in the login page");
            var passwordField = _browser.FindElementByPartialId($"{_loginUserContainerName}Password");
            Assert.IsNotNull(passwordField);
            passwordField.SendKeys(password);
        }

        public void ClickLoginButton(bool rememberPassword=false)
        {
            TickRememberPasswordCheckBox(rememberPassword);
            var loginButton = _browser.FindElementByPartialId($"{_loginUserContainerName}LoginButton");
            Assert.IsNotNull(loginButton);
            loginButton.Click();
            _log.Info($"Login button clicked");
        }


        public bool VerifyLoginSuccess()
        {
            _log.Info($"Verifying whether the login is success. Looking for Dashboard elements in the home page to confirm successful login");
            var logoutLink = _browser.FindElementByPartialClass("ico-logout");
            var myAccountLink = _browser.FindElementByPartialClass("account");
            return logoutLink != null && myAccountLink != null;
        }

        public void Logout()
        {
            _log.Info($"Logging out user");
            var logoutLink = _browser.FindElementByPartialClass("ico-logout");
            logoutLink.Click();
        }

        public bool HasErrorMessage(string errorMessage)
        {
            _log.Info($"Looking for any validation errors in the page");
            var messageElement = _browser.FindElementByPartialClass("message-error");
            return messageElement.Text == errorMessage;
        }

        public void TickRememberPasswordCheckBox(bool status)
        {
            var rememberPwdCheckBox = _browser.FindElementByPartialId($"{_loginUserContainerName}RememberMe");
            if (status && !rememberPwdCheckBox.Selected)
            {
                rememberPwdCheckBox.Click();
            }
            else if(!rememberPwdCheckBox.Selected)
            {
                rememberPwdCheckBox.Click();
            }
        }

        public void GotoAccountsPage()
        {
            Stopwatch watch = Stopwatch.StartNew();
            _log.Info($"Loading the nop-commerce page. Start time {DateTime.Now}");

            var accountElement = _browser.WebDriver.FindElementByClassName("account");
            accountElement.Click();

            _log.Info($"Time taken to load account page {watch.Elapsed.Seconds} seconds.");
            Thread.Sleep(3000);

            var emailElement = _browser.FindElementByPartialId("ctrlCustomerInfo_txtEmail");
            Assert.IsNotNull(emailElement);

            
            var logoutElement = _browser.WebDriver.FindElementByClassName("ico-logout");
            logoutElement.Click();
        
        }
    }
}
