using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ERM.AutomationTrial.Infrastructure;
using ERM.AutomationTrial.Infrastructure.Browser;
using ERM.AutomationTrial.Infrastructure.Utils;
using NUnit.Framework;
using OpenQA.Selenium;

namespace ERM.AutomationTrial.Pages
{
    public class RegistrationPage : BasePage
    {
        private static readonly log4net.ILog _log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private readonly string _createUserContainerName = Constants.WebFormContainerNames.NewUserRegistration;
        private readonly string _loginUserContainerName  = Constants.WebFormContainerNames.Login;
        public void GotoRegistrationPage()
        {
            _log.Info($"Loading registration page by clicking the 'register' link");
            GotoHomePage();
            var registrationElement  = _browser.WebDriver.FindElementByClassName("ico-register");
            registrationElement.Click();
        }

        public void EnterUserName(string userName)
        {
            _log.Info($"Entering username '{userName}' in the registration page");
            EnterFieldValue(_createUserContainerName, "UserName", userName);
        }

        public void EnterPassword(string password)
        {
            _log.Info($"Entering password '{password}' in the registration page");
            EnterFieldValue(_createUserContainerName, "Password", password);
        }

        public void ClickRegisterButton()
        {

            var registerButton =  _browser.FindElementByPartialId("StepNextButton");
            Assert.IsNotNull(registerButton);
            _log.Info($"Register button clicked");
            registerButton.Click();
        }

        public bool HasValidationErrorMessage(string errorMessage)
        {
            _log.Info($"Looking for validation summary message if any.");
            var validationSummarySection = _browser.FindElementByPartialClass($"message-error");

            _log.Debug(validationSummarySection.Text);
            return validationSummarySection.Text.Contains(errorMessage); 
        }

        public void EnterEmailAddress(string emailAddress)
        {
            _log.Info($"Entering emailaddress '{emailAddress}' in the registration page");
            EnterFieldValue(_createUserContainerName, "Email", emailAddress);
        }

        public void EnterLastName(string lastName)
        {
            _log.Info($"Entering lastname '{lastName}' in the registration page");
            EnterFieldValue(_createUserContainerName, "txtLastName", lastName);
        }

        public void EnterFirstName(string firstName)
        {
            _log.Info($"Entering firstName '{firstName}' in the registration page");
            EnterFieldValue(_createUserContainerName, "txtFirstName", firstName);
        }
        public void ConfirmPassword(string password)
        {
            EnterFieldValue(_createUserContainerName, "ConfirmPassword", password);
        }

        public bool IsRegistrationSuccess(string registrationMessage)
        {
            _log.Info($"Looking for registration success message in the page");
            var registrationMessageElement = _browser.FindElementByPartialId("CreateUserForm_CompleteStepContainer_lblCompleteStep");
            return registrationMessageElement.Text.Contains(registrationMessage);

        }

        public void GotoAccountsPage()
        {
            Stopwatch watch = Stopwatch.StartNew();
            _log.Info($"Loading the nop-commerce page. Start time {DateTime.Now}");

            GotoHomePage();

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
