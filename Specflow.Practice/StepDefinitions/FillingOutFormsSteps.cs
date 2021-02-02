using System;
using System.Text.RegularExpressions;
using QA.Upskill.Program.Tests.PageObjects.UltimateQA;
using QA.Upskill.Program.Tests.Models;
using TechTalk.SpecFlow;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;

namespace QA.Upskill.Program.Tests.StepDefinitions
{
    [Binding]
    public class FillingOutFormsSteps : BaseTest
    {
        readonly FillingOutFormsPage _fillingOutFormsPage;
        readonly ComplicatedPage _complicatedPage;

        public FillingOutFormsSteps(IWebDriver driver, FillingOutFormsPage fillingOutFormsPage, ComplicatedPage complicatedPage) : base(driver)
        {
            _fillingOutFormsPage = fillingOutFormsPage;
            _complicatedPage = complicatedPage;
        }

        [When(@"name (.*) in the Name field and message (.*) in the Message field are filled in form (.*)")]
        public void WhenNameInTheNameFieldAndMessageInTheMessageFieldAreFilled(string name, string message, string form)
        {
            string processedName = name.Replace("\"", "");
            string processedMessage = message.Replace("\"", "");
            if (form == "Form1")
            {
                _fillingOutFormsPage.NameField1.SendKeys(processedName);
                _fillingOutFormsPage.MessageBox1.SendKeys(processedMessage);
            }
            else if (form == "Form2")
            {
                _fillingOutFormsPage.NameField2.SendKeys(processedName);
                _fillingOutFormsPage.MessageBox2.SendKeys(processedMessage);
            }
        }

        [When(@"Submit (.*) button is clicked")]
        public void WhenSubmitButtonIsClicked(string button)
        {
            if (button == "Button1")
            {
                _fillingOutFormsPage.SubmitButton[0].Click();
            }
            else if (button == "Button2")
            {
                _fillingOutFormsPage.SubmitButton[1].Click();
            }
            else if (button == "Button3")
            {
                _complicatedPage.SubmitButton.Click();
            }
        }

        [Then(@"a text (.*) message is shown on the page")]
        public void ThenATextMessageIsShownOnThePage(string text)
        {
            if (text == "Success")
            {
                Assert.IsTrue(_fillingOutFormsPage.SuccessText1.Displayed);
                Assert.AreEqual("Form filled out successfully", _fillingOutFormsPage.SuccessText1.Text);
            }
            else if (text == "Failure")
            {
                Assert.IsTrue(_fillingOutFormsPage.Name1Warning.Displayed);
                Assert.IsTrue(_fillingOutFormsPage.Message1Warning.Displayed);
                Assert.IsTrue(_fillingOutFormsPage.WarningText1.Displayed);
                Assert.AreEqual("Name", _fillingOutFormsPage.Name1Warning.Text);
                Assert.AreEqual("Message", _fillingOutFormsPage.Message1Warning.Text);
                Assert.AreEqual("Please, fill in the following fields:", _fillingOutFormsPage.WarningText1.Text);
            }
            else if (text == "RequiredFieldsNotFilled")
            {
                Assert.IsTrue(_fillingOutFormsPage.FieldsWithOnlySpacesWarning1[0].Displayed);
                Assert.IsTrue(_fillingOutFormsPage.FieldsWithOnlySpacesWarning1[1].Displayed);
                Assert.AreEqual("Make sure you fill in all required fields.", _fillingOutFormsPage.FieldsWithOnlySpacesWarning1[0].Text);
                Assert.AreEqual("Make sure you fill in all required fields.", _fillingOutFormsPage.FieldsWithOnlySpacesWarning1[1].Text);
            }
            else if (text == "RequiredField2NotFilled")
            {
                Assert.IsTrue(_fillingOutFormsPage.FieldsWithOnlySpacesWarning1[0].Displayed);
                Assert.AreEqual("Make sure you fill in all required fields.", _fillingOutFormsPage.FieldsWithOnlySpacesWarning1[0].Text);
            }
            else if (text == "RequiredField1NotFilled")
            {
                Assert.IsTrue(_fillingOutFormsPage.FieldsWithOnlySpacesWarning1[0].Displayed);
                Assert.AreEqual("Make sure you fill in all required fields.", _fillingOutFormsPage.FieldsWithOnlySpacesWarning1[0].Text);
            }
            else if (text == "MessageWarning")
            {
                Assert.IsTrue(_fillingOutFormsPage.Message1Warning.Displayed);
                Assert.AreEqual("Message", _fillingOutFormsPage.Message1Warning.Text);
            }
            else if (text == "NameWarning")
            {
                Assert.IsTrue(_fillingOutFormsPage.Name1Warning.Displayed);
                Assert.AreEqual("Name", _fillingOutFormsPage.Name1Warning.Text);
            }
        }

        [When(@"captcha sum (.*) is filled in the Captcha field")]
        public void WhenCaptchaSumCorrectIsFilledInTheCaptchaField(string captchaValue)
        {
            int captchaSum = _fillingOutFormsPage.CaptchaSum(_fillingOutFormsPage.captchaFirstDigit, _fillingOutFormsPage.captchaSecondDigit);

            if (captchaValue == "correct")
            {
                _fillingOutFormsPage.SumField.SendKeys(captchaSum.ToString());
            }
            else if (captchaValue == "wrong")
            {
                _fillingOutFormsPage.SumField.SendKeys((captchaSum + 1).ToString());
            }
        }

        [Then(@"a text (.*) message is shown on the page above the form with Captcha")]
        public void ThenATextMessageIsShownOnThePageAboveTheFormWithCaptcha(string text)
        {
            if (text == "Success")
            {
                Assert.IsTrue(_fillingOutFormsPage.SuccessText2.Displayed);
                Assert.AreEqual("Success", _fillingOutFormsPage.SuccessText2.Text);
            }
            else if (text == "WrongNumberInCaptcha")
            {
                Assert.IsTrue(_fillingOutFormsPage.WrongNumberInCaptcha.Displayed);
                Assert.AreEqual("You entered the wrong number in captcha.", _fillingOutFormsPage.WrongNumberInCaptcha.Text);
            }
            else if (text == "CapthcaWarning")
            {
                Assert.IsTrue(_fillingOutFormsPage.WarningText2.Displayed);
                Assert.IsTrue(_fillingOutFormsPage.CapthcaWarning.Displayed);
                Assert.AreEqual("Please, fill in the following fields:", _fillingOutFormsPage.WarningText2.Text);
                Assert.AreEqual("Captcha", _fillingOutFormsPage.CapthcaWarning.Text);
            }
            else if (text == "WarningNameMessage")
            {
                Assert.IsTrue(_fillingOutFormsPage.WarningText2.Displayed);
                Assert.IsTrue(_fillingOutFormsPage.Name2Warning.Displayed);
                Assert.IsTrue(_fillingOutFormsPage.Message2Warning.Displayed);
                Assert.AreEqual("Please, fill in the following fields:", _fillingOutFormsPage.WarningText2.Text);
                Assert.AreEqual("Name", _fillingOutFormsPage.Name2Warning.Text);
                Assert.AreEqual("Message", _fillingOutFormsPage.Message2Warning.Text);
            }
            else if (text == "WarningNameMessageErrorCaptcha")
            {
                Assert.IsTrue(_fillingOutFormsPage.WarningText2.Displayed);
                Assert.IsTrue(_fillingOutFormsPage.Name2Warning.Displayed);
                Assert.IsTrue(_fillingOutFormsPage.Message2Warning.Displayed);
                Assert.IsTrue(_fillingOutFormsPage.ErrorsText.Displayed);
                Assert.IsTrue(_fillingOutFormsPage.WrongNumberInCaptcha.Displayed);
                Assert.AreEqual("Please, fill in the following fields:", _fillingOutFormsPage.WarningText2.Text);
                Assert.AreEqual("Name", _fillingOutFormsPage.Name2Warning.Text);
                Assert.AreEqual("Message", _fillingOutFormsPage.Message2Warning.Text);
                Assert.AreEqual("Please, fix the following errors:", _fillingOutFormsPage.ErrorsText.Text);
                Assert.AreEqual("You entered the wrong number in captcha.", _fillingOutFormsPage.WrongNumberInCaptcha.Text);
            }
            else if (text == "WarningAll")
            {
                Assert.IsTrue(_fillingOutFormsPage.WarningText2.Displayed);
                Assert.IsTrue(_fillingOutFormsPage.Name2Warning.Displayed);
                Assert.IsTrue(_fillingOutFormsPage.Message2Warning.Displayed);
                Assert.IsTrue(_fillingOutFormsPage.CapthcaWarning.Displayed);
                Assert.AreEqual("Please, fill in the following fields:", _fillingOutFormsPage.WarningText2.Text);
                Assert.AreEqual("Name", _fillingOutFormsPage.Name2Warning.Text);
                Assert.AreEqual("Message", _fillingOutFormsPage.Message2Warning.Text);
                Assert.AreEqual("Captcha", _fillingOutFormsPage.CapthcaWarning.Text);
            }
            else if (text == "RequiredFieldsNotFilled")
            {
                Assert.IsTrue(_fillingOutFormsPage.FieldsWithOnlySpacesWarning2[0].Displayed);
                Assert.IsTrue(_fillingOutFormsPage.FieldsWithOnlySpacesWarning2[1].Displayed);
                Assert.AreEqual("Make sure you fill in all required fields.", _fillingOutFormsPage.FieldsWithOnlySpacesWarning2[0].Text);
                Assert.AreEqual("Make sure you fill in all required fields.", _fillingOutFormsPage.FieldsWithOnlySpacesWarning2[1].Text);
            }
            else if (text == "NameWarning")
            {
                Assert.IsTrue(_fillingOutFormsPage.WarningText2.Displayed);
                Assert.IsTrue(_fillingOutFormsPage.Name2Warning.Displayed);
                Assert.AreEqual("Please, fill in the following fields:", _fillingOutFormsPage.WarningText2.Text);
                Assert.AreEqual("Name", _fillingOutFormsPage.Name2Warning.Text);
            }
            else if (text == "MessageWarning")
            {
                Assert.IsTrue(_fillingOutFormsPage.WarningText2.Displayed);
                Assert.IsTrue(_fillingOutFormsPage.Message2Warning.Displayed);
                Assert.AreEqual("Please, fill in the following fields:", _fillingOutFormsPage.WarningText2.Text);
                Assert.AreEqual("Message", _fillingOutFormsPage.Message2Warning.Text);
            }
            else if (text == "NameWarningErrorCaptcha")
            {
                Assert.IsTrue(_fillingOutFormsPage.WarningText2.Displayed);
                Assert.IsTrue(_fillingOutFormsPage.Name2Warning.Displayed);
                Assert.IsTrue(_fillingOutFormsPage.ErrorsText.Displayed);
                Assert.IsTrue(_fillingOutFormsPage.WrongNumberInCaptcha.Displayed);
                Assert.AreEqual("Please, fill in the following fields:", _fillingOutFormsPage.WarningText2.Text);
                Assert.AreEqual("Name", _fillingOutFormsPage.Name2Warning.Text);
                Assert.AreEqual("Please, fix the following errors:", _fillingOutFormsPage.ErrorsText.Text);
                Assert.AreEqual("You entered the wrong number in captcha.", _fillingOutFormsPage.WrongNumberInCaptcha.Text);
            }
            else if (text == "MessageWarningErrorCaptcha")
            {
                Assert.IsTrue(_fillingOutFormsPage.WarningText2.Displayed);
                Assert.IsTrue(_fillingOutFormsPage.Message2Warning.Displayed);
                Assert.IsTrue(_fillingOutFormsPage.ErrorsText.Displayed);
                Assert.IsTrue(_fillingOutFormsPage.WrongNumberInCaptcha.Displayed);
                Assert.AreEqual("Please, fill in the following fields:", _fillingOutFormsPage.WarningText2.Text);
                Assert.AreEqual("Message", _fillingOutFormsPage.Message2Warning.Text);
                Assert.AreEqual("Please, fix the following errors:", _fillingOutFormsPage.ErrorsText.Text);
                Assert.AreEqual("You entered the wrong number in captcha.", _fillingOutFormsPage.WrongNumberInCaptcha.Text);
            }
            else if (text == "WarningNameCaptcha")
            {
                Assert.IsTrue(_fillingOutFormsPage.WarningText2.Displayed);
                Assert.IsTrue(_fillingOutFormsPage.Name2Warning.Displayed);
                Assert.IsTrue(_fillingOutFormsPage.CapthcaWarning.Displayed);
                Assert.AreEqual("Please, fill in the following fields:", _fillingOutFormsPage.WarningText2.Text);
                Assert.AreEqual("Name", _fillingOutFormsPage.Name2Warning.Text);
                Assert.AreEqual("Captcha", _fillingOutFormsPage.CapthcaWarning.Text);
            }
            else if (text == "WarningMessageCaptcha")
            {
                Assert.IsTrue(_fillingOutFormsPage.WarningText2.Displayed);
                Assert.IsTrue(_fillingOutFormsPage.Message2Warning.Displayed);
                Assert.IsTrue(_fillingOutFormsPage.CapthcaWarning.Displayed);
                Assert.AreEqual("Please, fill in the following fields:", _fillingOutFormsPage.WarningText2.Text);
                Assert.AreEqual("Message", _fillingOutFormsPage.Message2Warning.Text);
                Assert.AreEqual("Captcha", _fillingOutFormsPage.CapthcaWarning.Text);
            }
            else if (text == "RequiredFieldNotFilled")
            {
                Assert.IsTrue(_fillingOutFormsPage.FieldsWithOnlySpacesWarning2[0].Displayed);
                Assert.AreEqual("Make sure you fill in all required fields.", _fillingOutFormsPage.FieldsWithOnlySpacesWarning2[0].Text);
            }
        }
        [When(@"the page is scrolled down to the form")]
        public void WhenThePageIsScrolledDownToTheForm()
        {
            Driver.ScrollToElement(_complicatedPage.RandomStuffSection);
        }

        [When(@"name (.*) is filled in the Name field")]
        public void WhenNameIsFilledInTheNameField(string name)
        {
            _complicatedPage.NameField.SendKeys(name);
        }

        [When(@"message (.*) is filled in the Message field")]
        public void WhenMessageIsFilledInTheMessageField(string message)
        {
            _complicatedPage.MessageField.SendKeys(message);
        }

        [When(@"email (.*) is filled in the Email field")]
        public void WhenEmailIsFilledInTheEmailField(string email)
        {
            _complicatedPage.EmailField.SendKeys(email);
        }

        [When(@"captcha sum (.*) is filled in the Captcha field in the form with Email")]
        public void WhenCaptchaSumIsFilledInTheCaptchaFieldInTheFormWithEmail(string captchaValue)
        {
            int captchaSum = _fillingOutFormsPage.CaptchaSum(_complicatedPage.captchaFirstDigit, _complicatedPage.captchaSecondDigit);

            if (captchaValue == "correct")
            {
                _complicatedPage.CaptchaSumField.SendKeys(captchaSum.ToString());
            }
            else if (captchaValue == "wrong")
            {
                _complicatedPage.CaptchaSumField.SendKeys((captchaSum + 1).ToString());
            }
        }

        [Then(@"a text (.*) message is shown on the page above the form with Email and Captcha")]
        public void ThenATextMessageIsShownOnThePageAboveTheFormWithEmailAndCaptcha(string text)
        {
            if (text == "Success")
            {
                Assert.IsTrue(_complicatedPage.SuccessfullyFilledFormText.Displayed);
                Assert.AreEqual("Thanks for contacting us", _complicatedPage.SuccessfullyFilledFormText.Text);
            }
            else if (text == "WrongNumberInCaptcha")
            {
                Assert.IsTrue(_complicatedPage.WrongNumberInCaptcha.Displayed);
                Assert.AreEqual("You entered the wrong number in captcha.", _complicatedPage.WrongNumberInCaptcha.Text);

            }
            else if (text == "CaptchaWarning")
            {
                Assert.IsTrue(_complicatedPage.WarningText.Displayed);
                Assert.IsTrue(_complicatedPage.CaptchaWarning.Displayed);
                Assert.AreEqual("Please, fill in the following fields:", _complicatedPage.WarningText.Text);
                Assert.AreEqual("Captcha", _complicatedPage.CaptchaWarning.Text);
            }
            else if (text == "InvalidEmail")
            {
                Assert.IsTrue(_complicatedPage.InvalidEmail.Displayed);
                Assert.AreEqual("Invalid email", _complicatedPage.InvalidEmail.Text);
            }
            else if (text == "InvalidEmailWrongNumberInCaptcha")
            {
                Assert.IsTrue(_complicatedPage.InvalidEmail.Displayed);
                Assert.AreEqual("Invalid email", _complicatedPage.InvalidEmail.Text);
                Assert.IsTrue(_complicatedPage.WrongNumberInCaptcha.Displayed);
                Assert.AreEqual("You entered the wrong number in captcha.", _complicatedPage.WrongNumberInCaptcha.Text);
            }
            else if (text == "InvalidEmailCaptchaWarning")
            {
                Assert.IsTrue(_complicatedPage.WarningText.Displayed);
                Assert.IsTrue(_complicatedPage.CaptchaWarning.Displayed);
                Assert.AreEqual("Please, fill in the following fields:", _complicatedPage.WarningText.Text);
                Assert.AreEqual("Captcha", _complicatedPage.CaptchaWarning.Text);
                Assert.IsTrue(_complicatedPage.InvalidEmail.Displayed);
                Assert.AreEqual("Invalid email", _complicatedPage.InvalidEmail.Text);
                Assert.IsTrue(_complicatedPage.FixTheErrorsText.Displayed);
                Assert.AreEqual("Please, fix the following errors:", _complicatedPage.FixTheErrorsText.Text);

            }
            else if (text == "EmailWarning")
            {
                Assert.IsTrue(_complicatedPage.EmailAddressWarning.Displayed);
                Assert.AreEqual("Email Address", _complicatedPage.EmailAddressWarning.Text);
                Assert.IsTrue(_complicatedPage.WarningText.Displayed);
                Assert.AreEqual("Please, fill in the following fields:", _complicatedPage.WarningText.Text);
            }
            else if (text == "EmailWarningWrongNumberInCaptcha")
            {
                Assert.IsTrue(_complicatedPage.EmailAddressWarning.Displayed);
                Assert.AreEqual("Email Address", _complicatedPage.EmailAddressWarning.Text);
                Assert.IsTrue(_complicatedPage.WarningText.Displayed);
                Assert.AreEqual("Please, fill in the following fields:", _complicatedPage.WarningText.Text);
                Assert.IsTrue(_complicatedPage.FixTheErrorsText.Displayed);
                Assert.AreEqual("Please, fix the following errors:", _complicatedPage.FixTheErrorsText.Text);
                Assert.IsTrue(_complicatedPage.WrongNumberInCaptcha.Displayed);
                Assert.AreEqual("You entered the wrong number in captcha.", _complicatedPage.WrongNumberInCaptcha.Text);

            }
            else if (text == "EmailCaptchaWarning")
            {
                Assert.IsTrue(_complicatedPage.WarningText.Displayed);
                Assert.AreEqual("Please, fill in the following fields:", _complicatedPage.WarningText.Text);
                Assert.IsTrue(_complicatedPage.EmailAddressWarning.Displayed);
                Assert.AreEqual("Email Address", _complicatedPage.EmailAddressWarning.Text);
                Assert.IsTrue(_complicatedPage.CaptchaWarning.Displayed);
                Assert.AreEqual("Captcha", _complicatedPage.CaptchaWarning.Text);
            }
            else if (text == "RequiredFieldNotFilled")
            {
                Assert.IsTrue(_complicatedPage.FillInAllRequiredFields[0].Displayed);
                Assert.AreEqual("Make sure you fill in all required fields.", _complicatedPage.FillInAllRequiredFields[0].Text);
            }
            else if (text == "NameEmailMessageWarning")
            {
                Assert.IsTrue(_complicatedPage.WarningText.Displayed);
                Assert.AreEqual("Please, fill in the following fields:", _complicatedPage.WarningText.Text);
                Assert.IsTrue(_complicatedPage.NameWarning.Displayed);
                Assert.AreEqual("Name", _complicatedPage.NameWarning.Text);
                Assert.IsTrue(_complicatedPage.EmailAddressWarning.Displayed);
                Assert.AreEqual("Email Address", _complicatedPage.EmailAddressWarning.Text);
                Assert.IsTrue(_complicatedPage.MessageWarning.Displayed);
                Assert.AreEqual("Message", _complicatedPage.MessageWarning.Text);
            }
            else if (text == "NameEmailMessageWarningWrongNumberInCaptcha")
            {
                Assert.IsTrue(_complicatedPage.WarningText.Displayed);
                Assert.AreEqual("Please, fill in the following fields:", _complicatedPage.WarningText.Text);
                Assert.IsTrue(_complicatedPage.NameWarning.Displayed);
                Assert.AreEqual("Name", _complicatedPage.NameWarning.Text);
                Assert.IsTrue(_complicatedPage.EmailAddressWarning.Displayed);
                Assert.AreEqual("Email Address", _complicatedPage.EmailAddressWarning.Text);
                Assert.IsTrue(_complicatedPage.MessageWarning.Displayed);
                Assert.AreEqual("Message", _complicatedPage.MessageWarning.Text);
                Assert.IsTrue(_complicatedPage.FixTheErrorsText.Displayed);
                Assert.AreEqual("Please, fix the following errors:", _complicatedPage.FixTheErrorsText.Text);
                Assert.IsTrue(_complicatedPage.WrongNumberInCaptcha.Displayed);
                Assert.AreEqual("You entered the wrong number in captcha.", _complicatedPage.WrongNumberInCaptcha.Text);

            }
            else if (text == "NameEmailMessageCaptchaWarning")
            {
                Assert.IsTrue(_complicatedPage.WarningText.Displayed);
                Assert.AreEqual("Please, fill in the following fields:", _complicatedPage.WarningText.Text);
                Assert.IsTrue(_complicatedPage.NameWarning.Displayed);
                Assert.AreEqual("Name", _complicatedPage.NameWarning.Text);
                Assert.IsTrue(_complicatedPage.EmailAddressWarning.Displayed);
                Assert.AreEqual("Email Address", _complicatedPage.EmailAddressWarning.Text);
                Assert.IsTrue(_complicatedPage.MessageWarning.Displayed);
                Assert.AreEqual("Message", _complicatedPage.MessageWarning.Text);
                Assert.IsTrue(_complicatedPage.CaptchaWarning.Displayed);
                Assert.AreEqual("Captcha", _complicatedPage.CaptchaWarning.Text);
            }
            else if (text == "NameMessageWarning")
            {
                Assert.IsTrue(_complicatedPage.WarningText.Displayed);
                Assert.AreEqual("Please, fill in the following fields:", _complicatedPage.WarningText.Text);
                Assert.IsTrue(_complicatedPage.NameWarning.Displayed);
                Assert.AreEqual("Name", _complicatedPage.NameWarning.Text);
                Assert.IsTrue(_complicatedPage.MessageWarning.Displayed);
                Assert.AreEqual("Message", _complicatedPage.MessageWarning.Text);

            }
            else if (text == "NameMessageWarningWrongNumberInCaptcha")
            {
                Assert.IsTrue(_complicatedPage.WarningText.Displayed);
                Assert.AreEqual("Please, fill in the following fields:", _complicatedPage.WarningText.Text);
                Assert.IsTrue(_complicatedPage.NameWarning.Displayed);
                Assert.AreEqual("Name", _complicatedPage.NameWarning.Text);
                Assert.IsTrue(_complicatedPage.MessageWarning.Displayed);
                Assert.AreEqual("Message", _complicatedPage.MessageWarning.Text);
                Assert.IsTrue(_complicatedPage.FixTheErrorsText.Displayed);
                Assert.AreEqual("Please, fix the following errors:", _complicatedPage.FixTheErrorsText.Text);
                Assert.IsTrue(_complicatedPage.WrongNumberInCaptcha.Displayed);
                Assert.AreEqual("You entered the wrong number in captcha.", _complicatedPage.WrongNumberInCaptcha.Text);
            }
            else if (text == "NameMessageCaptchaWarning")
            {
                Assert.IsTrue(_complicatedPage.WarningText.Displayed);
                Assert.AreEqual("Please, fill in the following fields:", _complicatedPage.WarningText.Text);
                Assert.IsTrue(_complicatedPage.NameWarning.Displayed);
                Assert.AreEqual("Name", _complicatedPage.NameWarning.Text);
                Assert.IsTrue(_complicatedPage.MessageWarning.Displayed);
                Assert.AreEqual("Message", _complicatedPage.MessageWarning.Text);
                Assert.IsTrue(_complicatedPage.CaptchaWarning.Displayed);
                Assert.AreEqual("Captcha", _complicatedPage.CaptchaWarning.Text);
            }
            else if (text == "MessageWarning")
            {
                Assert.IsTrue(_complicatedPage.WarningText.Displayed);
                Assert.AreEqual("Please, fill in the following fields:", _complicatedPage.WarningText.Text);
                Assert.IsTrue(_complicatedPage.MessageWarning.Displayed);
                Assert.AreEqual("Message", _complicatedPage.MessageWarning.Text);
            }
            else if (text == "MessageWarningWrongNumberInCaptcha")
            {
                Assert.IsTrue(_complicatedPage.WarningText.Displayed);
                Assert.AreEqual("Please, fill in the following fields:", _complicatedPage.WarningText.Text);
                Assert.IsTrue(_complicatedPage.MessageWarning.Displayed);
                Assert.AreEqual("Message", _complicatedPage.MessageWarning.Text);
                Assert.IsTrue(_complicatedPage.FixTheErrorsText.Displayed);
                Assert.AreEqual("Please, fix the following errors:", _complicatedPage.FixTheErrorsText.Text);
                Assert.IsTrue(_complicatedPage.WrongNumberInCaptcha.Displayed);
                Assert.AreEqual("You entered the wrong number in captcha.", _complicatedPage.WrongNumberInCaptcha.Text);
            }
            else if (text == "MessageCaptchaWarning")
            {
                Assert.IsTrue(_complicatedPage.WarningText.Displayed);
                Assert.AreEqual("Please, fill in the following fields:", _complicatedPage.WarningText.Text);
                Assert.IsTrue(_complicatedPage.MessageWarning.Displayed);
                Assert.AreEqual("Message", _complicatedPage.MessageWarning.Text);
                Assert.IsTrue(_complicatedPage.CaptchaWarning.Displayed);
                Assert.AreEqual("Captcha", _complicatedPage.CaptchaWarning.Text);
            }
            else if (text == "NameWarning")
            {
                Assert.IsTrue(_complicatedPage.WarningText.Displayed);
                Assert.AreEqual("Please, fill in the following fields:", _complicatedPage.WarningText.Text);
                Assert.IsTrue(_complicatedPage.NameWarning.Displayed);
                Assert.AreEqual("Name", _complicatedPage.NameWarning.Text);
            }
            else if (text == "NameWarningWrongNumberInCaptcha")
            {
                Assert.IsTrue(_complicatedPage.WarningText.Displayed);
                Assert.AreEqual("Please, fill in the following fields:", _complicatedPage.WarningText.Text);
                Assert.IsTrue(_complicatedPage.NameWarning.Displayed);
                Assert.AreEqual("Name", _complicatedPage.NameWarning.Text);
                Assert.IsTrue(_complicatedPage.FixTheErrorsText.Displayed);
                Assert.AreEqual("Please, fix the following errors:", _complicatedPage.FixTheErrorsText.Text);
                Assert.IsTrue(_complicatedPage.WrongNumberInCaptcha.Displayed);
                Assert.AreEqual("You entered the wrong number in captcha.", _complicatedPage.WrongNumberInCaptcha.Text);
            }
            else if (text == "NameCaptchaWarning")
            {
                Assert.IsTrue(_complicatedPage.WarningText.Displayed);
                Assert.AreEqual("Please, fill in the following fields:", _complicatedPage.WarningText.Text);
                Assert.IsTrue(_complicatedPage.NameWarning.Displayed);
                Assert.AreEqual("Name", _complicatedPage.NameWarning.Text);
                Assert.IsTrue(_complicatedPage.CaptchaWarning.Displayed);
                Assert.AreEqual("Captcha", _complicatedPage.CaptchaWarning.Text);
            }
            else if (text == "EmailMessageWarning")
            {
                Assert.IsTrue(_complicatedPage.WarningText.Displayed);
                Assert.AreEqual("Please, fill in the following fields:", _complicatedPage.WarningText.Text);
                Assert.IsTrue(_complicatedPage.EmailAddressWarning.Displayed);
                Assert.AreEqual("Email Address", _complicatedPage.EmailAddressWarning.Text);
                Assert.IsTrue(_complicatedPage.MessageWarning.Displayed);
                Assert.AreEqual("Message", _complicatedPage.MessageWarning.Text);
            }
            else if (text == "EmailMessageWarningWrongNumberInCaptcha")
            {
                Assert.IsTrue(_complicatedPage.WarningText.Displayed);
                Assert.AreEqual("Please, fill in the following fields:", _complicatedPage.WarningText.Text);
                Assert.IsTrue(_complicatedPage.EmailAddressWarning.Displayed);
                Assert.AreEqual("Email Address", _complicatedPage.EmailAddressWarning.Text);
                Assert.IsTrue(_complicatedPage.MessageWarning.Displayed);
                Assert.AreEqual("Message", _complicatedPage.MessageWarning.Text);
                Assert.IsTrue(_complicatedPage.FixTheErrorsText.Displayed);
                Assert.AreEqual("Please, fix the following errors:", _complicatedPage.FixTheErrorsText.Text);
                Assert.IsTrue(_complicatedPage.WrongNumberInCaptcha.Displayed);
                Assert.AreEqual("You entered the wrong number in captcha.", _complicatedPage.WrongNumberInCaptcha.Text);
            }
            else if (text == "EmailMessageCaptchaWarning")
            {
                Assert.IsTrue(_complicatedPage.WarningText.Displayed);
                Assert.AreEqual("Please, fill in the following fields:", _complicatedPage.WarningText.Text);
                Assert.IsTrue(_complicatedPage.EmailAddressWarning.Displayed);
                Assert.AreEqual("Email Address", _complicatedPage.EmailAddressWarning.Text);
                Assert.IsTrue(_complicatedPage.MessageWarning.Displayed);
                Assert.AreEqual("Message", _complicatedPage.MessageWarning.Text);
                Assert.IsTrue(_complicatedPage.CaptchaWarning.Displayed);
                Assert.AreEqual("Captcha", _complicatedPage.CaptchaWarning.Text);
            }
            else if (text == "NameEmailWarning")
            {
                Assert.IsTrue(_complicatedPage.WarningText.Displayed);
                Assert.AreEqual("Please, fill in the following fields:", _complicatedPage.WarningText.Text);
                Assert.IsTrue(_complicatedPage.NameWarning.Displayed);
                Assert.AreEqual("Name", _complicatedPage.NameWarning.Text);
                Assert.IsTrue(_complicatedPage.EmailAddressWarning.Displayed);
                Assert.AreEqual("Email Address", _complicatedPage.EmailAddressWarning.Text);
            }
            else if (text == "NameEmailWarningWrongNumberInCaptcha")
            {
                Assert.IsTrue(_complicatedPage.WarningText.Displayed);
                Assert.AreEqual("Please, fill in the following fields:", _complicatedPage.WarningText.Text);
                Assert.IsTrue(_complicatedPage.NameWarning.Displayed);
                Assert.AreEqual("Name", _complicatedPage.NameWarning.Text);
                Assert.IsTrue(_complicatedPage.EmailAddressWarning.Displayed);
                Assert.AreEqual("Email Address", _complicatedPage.EmailAddressWarning.Text);
                Assert.IsTrue(_complicatedPage.FixTheErrorsText.Displayed);
                Assert.AreEqual("Please, fix the following errors:", _complicatedPage.FixTheErrorsText.Text);
                Assert.IsTrue(_complicatedPage.WrongNumberInCaptcha.Displayed);
                Assert.AreEqual("You entered the wrong number in captcha.", _complicatedPage.WrongNumberInCaptcha.Text);
            }
            else if (text == "NameEmailCaptchaWarning")
            {
                Assert.IsTrue(_complicatedPage.WarningText.Displayed);
                Assert.AreEqual("Please, fill in the following fields:", _complicatedPage.WarningText.Text);
                Assert.IsTrue(_complicatedPage.NameWarning.Displayed);
                Assert.AreEqual("Name", _complicatedPage.NameWarning.Text);
                Assert.IsTrue(_complicatedPage.EmailAddressWarning.Displayed);
                Assert.AreEqual("Email Address", _complicatedPage.EmailAddressWarning.Text);
                Assert.IsTrue(_complicatedPage.CaptchaWarning.Displayed);
                Assert.AreEqual("Captcha", _complicatedPage.CaptchaWarning.Text);
            }
            else if (text == "InvalidEmailNameWarning")
            {
                Assert.IsTrue(_complicatedPage.InvalidEmail.Displayed);
                Assert.AreEqual("Invalid email", _complicatedPage.InvalidEmail.Text);
                Assert.IsTrue(_complicatedPage.WarningText.Displayed);
                Assert.AreEqual("Please, fill in the following fields:", _complicatedPage.WarningText.Text);
                Assert.IsTrue(_complicatedPage.NameWarning.Displayed);
                Assert.AreEqual("Name", _complicatedPage.NameWarning.Text);
            }
            else if (text == "InvalidEmailNameWarningWrongNumberInCaptcha")
            {
                Assert.IsTrue(_complicatedPage.InvalidEmail.Displayed);
                Assert.AreEqual("Invalid email", _complicatedPage.InvalidEmail.Text);
                Assert.IsTrue(_complicatedPage.WarningText.Displayed);
                Assert.AreEqual("Please, fill in the following fields:", _complicatedPage.WarningText.Text);
                Assert.IsTrue(_complicatedPage.NameWarning.Displayed);
                Assert.AreEqual("Name", _complicatedPage.NameWarning.Text);
                Assert.IsTrue(_complicatedPage.FixTheErrorsText.Displayed);
                Assert.AreEqual("Please, fix the following errors:", _complicatedPage.FixTheErrorsText.Text);
                Assert.IsTrue(_complicatedPage.WrongNumberInCaptcha.Displayed);
                Assert.AreEqual("You entered the wrong number in captcha.", _complicatedPage.WrongNumberInCaptcha.Text);
            }
            else if (text == "InvalidEmailNameCaptchaWarning")
            {
                Assert.IsTrue(_complicatedPage.InvalidEmail.Displayed);
                Assert.AreEqual("Invalid email", _complicatedPage.InvalidEmail.Text);
                Assert.IsTrue(_complicatedPage.WarningText.Displayed);
                Assert.AreEqual("Please, fill in the following fields:", _complicatedPage.WarningText.Text);
                Assert.IsTrue(_complicatedPage.NameWarning.Displayed);
                Assert.AreEqual("Name", _complicatedPage.NameWarning.Text);
                Assert.IsTrue(_complicatedPage.CaptchaWarning.Displayed);
                Assert.AreEqual("Captcha", _complicatedPage.CaptchaWarning.Text);
            }
            else if (text == "InvalidEmailMessageWarning")
            {
                Assert.IsTrue(_complicatedPage.InvalidEmail.Displayed);
                Assert.AreEqual("Invalid email", _complicatedPage.InvalidEmail.Text);
                Assert.IsTrue(_complicatedPage.WarningText.Displayed);
                Assert.AreEqual("Please, fill in the following fields:", _complicatedPage.WarningText.Text);
                Assert.IsTrue(_complicatedPage.MessageWarning.Displayed);
                Assert.AreEqual("Message", _complicatedPage.MessageWarning.Text);
            }
            else if (text == "InvalidEmailMessageWarningWrongNumberInCaptcha")
            {
                Assert.IsTrue(_complicatedPage.InvalidEmail.Displayed);
                Assert.AreEqual("Invalid email", _complicatedPage.InvalidEmail.Text);
                Assert.IsTrue(_complicatedPage.WarningText.Displayed);
                Assert.AreEqual("Please, fill in the following fields:", _complicatedPage.WarningText.Text);
                Assert.IsTrue(_complicatedPage.MessageWarning.Displayed);
                Assert.AreEqual("Message", _complicatedPage.MessageWarning.Text);
                Assert.IsTrue(_complicatedPage.FixTheErrorsText.Displayed);
                Assert.AreEqual("Please, fix the following errors:", _complicatedPage.FixTheErrorsText.Text);
                Assert.IsTrue(_complicatedPage.WrongNumberInCaptcha.Displayed);
                Assert.AreEqual("You entered the wrong number in captcha.", _complicatedPage.WrongNumberInCaptcha.Text);
            }
            else if (text == "InvalidEmailMessageCaptchaWarning")
            {
                Assert.IsTrue(_complicatedPage.InvalidEmail.Displayed);
                Assert.AreEqual("Invalid email", _complicatedPage.InvalidEmail.Text);
                Assert.IsTrue(_complicatedPage.WarningText.Displayed);
                Assert.AreEqual("Please, fill in the following fields:", _complicatedPage.WarningText.Text);
                Assert.IsTrue(_complicatedPage.MessageWarning.Displayed);
                Assert.AreEqual("Message", _complicatedPage.MessageWarning.Text);
                Assert.IsTrue(_complicatedPage.CaptchaWarning.Displayed);
                Assert.AreEqual("Captcha", _complicatedPage.CaptchaWarning.Text);
            }
            else if (text == "RequiredFields3NotFilled")
            {
                Assert.IsTrue(_complicatedPage.FillInAllRequiredFields[0].Displayed);
                Assert.AreEqual("Make sure you fill in all required fields.", _complicatedPage.FillInAllRequiredFields[0].Text);
                Assert.IsTrue(_complicatedPage.FillInAllRequiredFields[1].Displayed);
                Assert.AreEqual("Make sure you fill in all required fields.", _complicatedPage.FillInAllRequiredFields[1].Text);
                Assert.IsTrue(_complicatedPage.FillInAllRequiredFields[2].Displayed);
                Assert.AreEqual("Make sure you fill in all required fields.", _complicatedPage.FillInAllRequiredFields[2].Text);
            }
            else if (text == "RequiredFields2NotFilled")
            {
                Assert.IsTrue(_complicatedPage.FillInAllRequiredFields[0].Displayed);
                Assert.AreEqual("Make sure you fill in all required fields.", _complicatedPage.FillInAllRequiredFields[0].Text);
                Assert.IsTrue(_complicatedPage.FillInAllRequiredFields[1].Displayed);
                Assert.AreEqual("Make sure you fill in all required fields.", _complicatedPage.FillInAllRequiredFields[1].Text);
            }
        }
    }
}
