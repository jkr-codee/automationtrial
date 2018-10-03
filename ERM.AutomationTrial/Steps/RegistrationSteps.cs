using System;
using System.Threading;
using ERM.AutomationTrial.Pages;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace ERM.AutomationTrial.Steps
{
    [Binding]
    [Scope(Feature = "New User Registration")]
    public class RegistrationSteps
    {
        private static RegistrationPage _registrationPage;
        private readonly DateTime _currentTime;

        public RegistrationSteps()
        {
            if (_registrationPage == null)
                _registrationPage = new RegistrationPage();

            _currentTime = DateTime.Now;

        }

        [Given(@"I navigate to nop-commerce web site registration page")]
        public void GivenINavigateToNop_CommerceWebSiteRegistrationPage()
        {
            _registrationPage.GotoRegistrationPage();
        }

        [When(@"I press Register button")]
        public void WhenIPressRegisterButtonWithoutEnteringAnyDetails()
        {
            _registrationPage.ClickRegisterButton();
        }

        [Then(@"System should throw validation error message as '(.*)'")]
        public void ThenSystemShouldThrowValidationErrorMessageAs(string errorMessage)
        {
            Assert.IsTrue(_registrationPage.HasValidationErrorMessage(errorMessage));
        }


        [Given(@"I enter first name as '(.*)'")]
        public void GivenIEnterFirstNameAs(string firstName)
        {
            _registrationPage.EnterFirstName(firstName);
        }

        [Given(@"I enter username as '(.*)'")]
        public void GivenIEnterUserNameAs(string userName)
        {
            var newUserName = String.Format(userName, _currentTime);
            _registrationPage.EnterUserName(newUserName);
        }

        [Given(@"I enter the password as '(.*)'")]
        public void GivenIEnterThePasswordAs(string password)
        {
            _registrationPage.EnterPassword(password);
        }

        [Given(@"I re-enter the password as '(.*)'")]
        public void GivenIReEnterThePasswordAs(string password)
        {
            
            _registrationPage.ConfirmPassword(password);
        }

        [Given(@"I enter last name as '(.*)'")]
        public void GivenIEnterLastNameAs(string lastName)
        {
            _registrationPage.EnterLastName(lastName);
        }

        [Given(@"I enter email as '(.*)'")]
        public void GivenIEnterEmailAs(string emailAddressExpression)
        {
            var newEmail = String.Format(emailAddressExpression, _currentTime);
            ScenarioContext.Current["emailAddress"] = newEmail;
            _registrationPage.EnterEmailAddress(newEmail);
        }

        [Then(@"The registration should be successfull")]
        public void ThenTheRegistrationShouldBeSuccessfull()
        {
            _registrationPage.IsRegistrationSuccess(String.Empty);
        }

        [Then(@"A message page should be displayed as '(.*)'")]
        public void ThenAMessagePageShouldBeDisplayedAs(string message)
        {
            Assert.IsTrue(_registrationPage.IsRegistrationSuccess(message));
        }

        [Then(@"I should be able to access account dashboard")]
        public void ThenIShouldBeAbleToLoginWithTheNewUser()
        {
            _registrationPage.GotoAccountsPage();

        }

        [AfterFeature()]
        public static void AfterFeature()
        {
            _registrationPage.CloseBrowser();
        }
    }
}
