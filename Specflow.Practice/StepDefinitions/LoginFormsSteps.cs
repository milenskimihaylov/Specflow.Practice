using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using QA.Upskill.Program.Tests.PageObjects.UltimateQA;
using TechTalk.SpecFlow;

namespace QA.Upskill.Program.Tests.StepDefinitions
{
    [Binding]
    public class LoginFormsSteps : BaseTest
    {
        readonly ComplicatedPage _complicatedPage;
        readonly UnregisteredUserPage _unregisteredUserPage;
        readonly ForgottenPasswordComplicatedLogin _forgottenPasswordComplicatedLogin;
        readonly LandingPage _landingPage;

        public LoginFormsSteps(IWebDriver driver, ComplicatedPage complicatedPage, UnregisteredUserPage unregisteredUserPage,
            ForgottenPasswordComplicatedLogin forgottenPasswordComplicatedLogin, LandingPage landingPage) : base(driver)
        {
            _complicatedPage = complicatedPage;
            _unregisteredUserPage = unregisteredUserPage;
            _forgottenPasswordComplicatedLogin = forgottenPasswordComplicatedLogin;
            _landingPage = landingPage;
        }

        [When(@"Username (.*) is entered")]
        public void WhenUsernameIsEntered(string username)
        {
            _complicatedPage.UsernameField.FillIn(username);
        }

        [When(@"Password (.*) is entered")]
        public void WhenPasswordIsEntered(string password)
        {
            _complicatedPage.PasswordField.FillIn(password);
        }

        [When(@"Login button is clicked")]
        public void WhenLoginButtonIsClicked()
        {
            _complicatedPage.ClickOnLoginButton();
        }

        [When(@"Forgot password link is clicked")]
        public void WhenForgotPasswordLinkIsClicked()
        {
            _complicatedPage.ForgotPassword.Click();
        }

        [Then(@"the user is redirected to (.*)")]
        public void ThenTheUserIsRedirectedTo(string webpage)
        {
            Assert.AreEqual(webpage, Driver.Url);
        }

        [Then(@"a message for ""(.*)"" is shown")]
        public void ThenAMessageForIsShown(string message)
        {
            if (message == "unsuccessfull login")
            {
                Driver.WaitElementToExists(_unregisteredUserPage.MessageLocator);

                Assert.IsTrue(_unregisteredUserPage.Message.Displayed);
                Assert.IsTrue(_unregisteredUserPage.Message.Text.Contains("Unknown username. Check again or try your email address."));
            }
            else if (message == "forgotten password")
            {
                Driver.WaitElementToExists(_forgottenPasswordComplicatedLogin.messageLocator);

                Assert.IsTrue(_forgottenPasswordComplicatedLogin.Message.Displayed);
                Assert.AreEqual("Please enter your username or email address. You will receive an email message with instructions on how to reset your password.", _forgottenPasswordComplicatedLogin.Message.Text);
            }
            else if (message == "empty fields")
            {
                Driver.WaitElementToExists(_unregisteredUserPage.MessageLocator);

                Assert.IsTrue(Driver.PageSource.Contains("<strong>Error</strong>: The username field is empty."));
                Assert.IsTrue(Driver.PageSource.Contains("<strong>Error</strong>: The password field is empty."));
            }
            else if (message == "password missing")
            {
                Driver.WaitElementToExists(_unregisteredUserPage.MessageLocator);

                Assert.IsTrue(Driver.PageSource.Contains("<strong>Error</strong>: The password field is empty."));
            }
            else if (message == "username missing")
            {
                Driver.WaitElementToExists(_unregisteredUserPage.MessageLocator);

                Assert.IsTrue(Driver.PageSource.Contains("<strong>Error</strong>: The username field is empty."));
            }
        }

        [Then(@"a form ""(.*)"" is shown")]
        public void ThenAFormIsShown(string form)
        {
            if (form == "Try again")
            {
                Assert.IsTrue(_unregisteredUserPage.UsernameInput.Displayed);
                Assert.IsTrue(_unregisteredUserPage.PasswordInput.Displayed);
                Assert.IsTrue(_unregisteredUserPage.SubmitButton.Displayed);
            }
            else if (form == "Username or Email Address")
            {
                Assert.IsTrue(_forgottenPasswordComplicatedLogin.UsernameInput.Displayed);
                Assert.IsTrue(_forgottenPasswordComplicatedLogin.GetNewPasswordButton.Displayed);
            }
        }
    }
}
