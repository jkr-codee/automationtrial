using System;
using System.Threading;
using ERM.AutomationTrial.Infrastructure;
using ERM.AutomationTrial.Infrastructure.Browser;
using ERM.AutomationTrial.Infrastructure.Utils;
using ERM.AutomationTrial.Pages;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace ERM.AutomationTrial.Steps
{
    [Binding]
    [Scope(Feature ="Login")]
    public class LoginSteps
    {
        private static LoginPage _loginPage;
        
        public LoginSteps()
        {
            if(_loginPage==null)
                _loginPage = new LoginPage();

        }

        

        [Given(@"I navigate to nop-commerce web site login page")]
        public void GivenINavigateToNop_CommerceWebSiteLoginPage()
        {
            _loginPage.GotoLoginPage();
        }

        [When(@"I press Login button")]
        public void WhenIPressLoginButton()
        {
            _loginPage.ClickLoginButton();
        }

        [When(@"I press Login button after valid details are entered")]
        public void WhenIPressLoginButtonAfterValidDetailsAreEntered()
        {
            Thread.Sleep(1000);
            _loginPage.ClickLoginButton();

        }


        [Then(@"I should be able to successfully login to nop-commerce platform")]
        public void ThenIShouldBeAbleToSuccessfullyLoginToNop_CommercePlatform()
        {
            _loginPage.VerifyLoginSuccess();
            _loginPage.Logout();
        }

        [Then(@"I should get a message as '(.*)'")]
        public void ThenIShouldGetAMessageAs(string errorMessage)
        {
            Assert.IsTrue(_loginPage.HasErrorMessage(errorMessage));
        }

        [Given(@"I enter username as '(.*)'")]
        public void GivenIEnterUsernameAs(string userName)
        {
            _loginPage.EnterUserName(userName);
        }

        [Given(@"I enter password as '(.*)'")]
        public void GivenIEnterPasswordAs(string password)
        {
            ScenarioContext.Current["password"] = password;
            _loginPage.EnterPassword(password);
            
        }

        [Then(@"I should be able to goto my account dashboard")]
        public void ThenIShouldBeAbleToLoginWithTheNewUser()
        {
            _loginPage.GotoAccountsPage();

        }
        [Given(@"I Choose remember password checkbox and I press Login button")]
        public void GivenIChooseRememberPasswordCheckboxAndIPressLoginButton()
        {
            _loginPage.ClickLoginButton(true);
        }

        [Then(@"I Close the browser and I reopen the browser")]
        public void ThenICloseTheBrowserAndIReopenTheBrowser()
        {
            _loginPage.NewBrowser();
        }

        [Then(@"I navigate to nop-commerce website")]
        public void ThenINavigateToNop_CommerceWebsite()
        {
            _loginPage.GotoHomePage();
        }

        [Then(@"I should have already logged in")]
        public void ThenIShouldHaveAlreadyLoggedIn()
        {
            _loginPage.VerifyLoginSuccess();
        }

        [AfterFeature()]
        public static void AfterFeature()
        {
            _loginPage.CloseBrowser();
        }
    }
}
