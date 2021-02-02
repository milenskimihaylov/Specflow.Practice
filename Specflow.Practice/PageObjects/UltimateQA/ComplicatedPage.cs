using System;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace QA.Upskill.Program.Tests.PageObjects.UltimateQA
{
    public class ComplicatedPage : BasePage
    {
        public ComplicatedPage(IWebDriver driver) : base(driver)
        {
        }

        public string URL => Driver.Url;

        public string Title => Driver.Title;

        public List<IWebElement> Button => Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.CssSelector("a.et_pb_button"))).ToList();

        public IWebElement RandomStuffSection => Wait.Until(d => d.FindElement(By.CssSelector(".et_pb_row_5")));

        public IWebElement NameField => Driver.FindElement(By.Id("et_pb_contact_name_0"));

        public IWebElement EmailField => Driver.FindElement(By.Id("et_pb_contact_email_0"));

        public IWebElement MessageField => Driver.FindElement(By.Id("et_pb_contact_message_0"));

        public IWebElement CaptchaSumField => Wait.Until(d => d.FindElement(By.CssSelector("input.et_pb_contact_captcha")));

        public IWebElement SubmitButton => Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.CssSelector("#et_pb_contact_form_0 .et_pb_button")));

        public IWebElement WarningText => Wait.Until(d => d.FindElement(By.XPath("//div[@id='et_pb_contact_form_0']//p[text()='Please, fill in the following fields:']")));

        public IWebElement SuccessfullyFilledFormText => Wait.Until(d => d.FindElement(By.XPath("//div[@id='et_pb_contact_form_0']//p[text()='Thanks for contacting us']")));

        public IWebElement FixTheErrorsText => Wait.Until(d => d.FindElement(By.XPath("//div[@id='et_pb_contact_form_0']//p[text()='Please, fix the following errors:']")));

        public List<IWebElement> FillInAllRequiredFields => Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//div[@id='et_pb_contact_form_0']//p[text()='Make sure you fill in all required fields.']"))).ToList();

        public IWebElement NameWarning => Wait.Until(d => d.FindElement(By.XPath("//div[@id='et_pb_contact_form_0']//li[text()='Name']")));

        public IWebElement EmailAddressWarning => Wait.Until(d => d.FindElement(By.XPath("//div[@id='et_pb_contact_form_0']//li[text()='Email Address']")));

        public IWebElement InvalidEmail => Wait.Until(d => d.FindElement(By.XPath("//div[@id='et_pb_contact_form_0']//li[text()='Invalid email']")));

        public IWebElement MessageWarning => Wait.Until(d => d.FindElement(By.XPath("//div[@id='et_pb_contact_form_0']//li[text()='Message']")));

        public IWebElement CaptchaWarning => Wait.Until(d => d.FindElement(By.XPath("//div[@id='et_pb_contact_form_0']//li[text()='Captcha']")));

        public IWebElement WrongNumberInCaptcha => Wait.Until(d => d.FindElement(By.XPath("//div[@id='et_pb_contact_form_0']//li[text()='You entered the wrong number in captcha.']")));

        public IWebElement UsernameField => Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[contains(@class, 'et_pb_login_0')]//input[@name='log']")));

        public IWebElement PasswordField => Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[contains(@class, 'et_pb_login_0')]//input[@name='pwd']")));

        public IWebElement LoginButton => Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.CssSelector(".et_pb_login_0 button")));

        public IWebElement ForgotPassword => Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.CssSelector(".et_pb_login_0 .et_pb_forgot_password > a")));

        public IWebElement DivLoginForm => Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector("div.et_pb_login_0")));

        public IWebElement DivToggle => Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.CssSelector("div.et_pb_toggle_0")));

        public IWebElement Toggle => Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.CssSelector("h5.et_pb_toggle_title")));

        public IWebElement ToggleContent => Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector("div.et_pb_toggle_content")));

        public bool ToggleContentIsHidden => Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.CssSelector("div.et_pb_toggle_content")));

        public string captchaFirstDigit => CaptchaSumField.GetAttribute("data-first_digit");

        public string captchaSecondDigit => CaptchaSumField.GetAttribute("data-second_digit");

        public string ToggleText => ToggleContent.Text;

        public bool ToggleIsDisplayed => ToggleContent.Displayed;

        public void ClickOnLoginButton()
        {
            LoginButton.Click();
        }

        public void ButtonClick(int buttonsNumber)
        {
            if (buttonsNumber == 1)
            {
                var random = new Random();
                var randomButton = random.Next(Button.Count);

                Button[randomButton].Click();
            }
            else
            {
                for (int i = 0; i < buttonsNumber; i++)
                {
                    Button[i].Click();
                }
            }
        }
    }
}
