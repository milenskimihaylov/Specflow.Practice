using System;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace QA.Upskill.Program.Tests.PageObjects.UltimateQA
{
    public class UnregisteredUserPage : BasePage
    {
        public UnregisteredUserPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//div[@id='login_error']")]
        public IWebElement Message { get; set; }
        public By MessageLocator => By.XPath("//div[@id='login_error']");
        
        [FindsBy(How = How.Id, Using = "user_login")]
        public IWebElement UsernameInput { get; set; }

        [FindsBy(How = How.Id, Using = "user_pass")]
        public IWebElement PasswordInput { get; set; }

        [FindsBy(How = How.XPath, Using = "//p//input[@id='user_login']")]
        public IWebElement SubmitButton { get; set; }

        public string URL => Driver.Url;

        public string Title => Driver.Title;


    }
}
