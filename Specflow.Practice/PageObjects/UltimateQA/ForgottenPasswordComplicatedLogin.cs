using System;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace QA.Upskill.Program.Tests.PageObjects.UltimateQA
{
    public class ForgottenPasswordComplicatedLogin : BasePage
    {
        public ForgottenPasswordComplicatedLogin(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.ClassName, Using = "message")]
        public IWebElement Message { get; set; }
        public By messageLocator => By.ClassName("message");

        [FindsBy(How = How.Id, Using = "user_login")]
        public IWebElement UsernameInput { get; set; }

        [FindsBy(How = How.Id, Using = "wp-submit")]
        public IWebElement GetNewPasswordButton { get; set; }

        public string URL => Driver.Url;

        public string Title => Driver.Title;
    }
}
