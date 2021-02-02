using System;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace QA.Upskill.Program.Tests.PageObjects.UltimateQA
{
    public class FillingOutFormsPage : BasePage
    {
        public FillingOutFormsPage(IWebDriver driver) : base(driver)
        {
        }

        public string URL => Driver.Url;

        public string Title => Driver.Title;

        public IWebElement NameField1 => Wait.Until(d => d.FindElement(By.Id("et_pb_contact_name_0")));

        public IWebElement NameField2 => Wait.Until(d => d.FindElement(By.Id("et_pb_contact_name_1")));

        public IWebElement MessageBox1 => Wait.Until(d => d.FindElement(By.Id("et_pb_contact_message_0")));

        public IWebElement MessageBox2 => Wait.Until(d => d.FindElement(By.Id("et_pb_contact_message_1")));

        public List<IWebElement> SubmitButton => Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.CssSelector(".et_pb_contact_submit.et_pb_button"))).ToList();

        public IWebElement SumField => Wait.Until(d => d.FindElement(By.CssSelector("input.et_pb_contact_captcha")));

        public IWebElement WarningText1 => Wait.Until(d => d.FindElement(By.XPath("//div[@id='et_pb_contact_form_0']//p[text()='Please, fill in the following fields:']")));

        public IWebElement WarningText2 => Wait.Until(d => d.FindElement(By.XPath("//div[@id='et_pb_contact_form_1']//p[text()='Please, fill in the following fields:']")));

        public IWebElement Name1Warning => Wait.Until(d => d.FindElement(By.XPath("//div[@id='et_pb_contact_form_0']//li[text()='Name']")));

        public IWebElement Name2Warning => Wait.Until(d => d.FindElement(By.XPath("//div[@id='et_pb_contact_form_1']//li[text()='Name']")));

        public IWebElement Message1Warning => Wait.Until(d => d.FindElement(By.XPath("//div[@id='et_pb_contact_form_0']//li[text()='Message']")));

        public IWebElement Message2Warning => Wait.Until(d => d.FindElement(By.XPath("//div[@id='et_pb_contact_form_1']//li[text()='Message']")));

        public IWebElement CapthcaWarning => Wait.Until(d => d.FindElement(By.XPath("//div[@id='et_pb_contact_form_1']//li[text()='Captcha']")));

        public IWebElement SuccessText1 => Wait.Until(d => d.FindElement(By.XPath("//div[@id='et_pb_contact_form_0']//p[text()='Form filled out successfully']")));

        public IWebElement SuccessText2 => Wait.Until(d => d.FindElement(By.XPath("//div[@id='et_pb_contact_form_1']//p[text()='Success']")));

        public List<IWebElement> FieldsWithOnlySpacesWarning1 => Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//div[@id='et_pb_contact_form_0']//p[text()='Make sure you fill in all required fields.']"))).ToList();

        public List<IWebElement> FieldsWithOnlySpacesWarning2 => Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//div[@id='et_pb_contact_form_1']//p[text()='Make sure you fill in all required fields.']"))).ToList();

        public IWebElement ErrorsText => Wait.Until(d => d.FindElement(By.XPath("//div[@id='et_pb_contact_form_1']//p[text()='Please, fix the following errors:']")));

        public IWebElement WrongNumberInCaptcha => Wait.Until(d => d.FindElement(By.XPath("//div[@id='et_pb_contact_form_1']//li[text()='You entered the wrong number in captcha.']")));

        public string captchaFirstDigit => SumField.GetAttribute("data-first_digit");

        public string captchaSecondDigit => SumField.GetAttribute("data-second_digit");

        public int CaptchaSum(string firstNumber, string secondNumber)
        {
            int sum = int.Parse(firstNumber) + int.Parse(secondNumber);

            return sum;
        }

        //public bool TextContainsLettersAndNumbers(string text)
        //{
        //    return Regex.Matches(text, @"[[a - zA - Z0 - 9]").Count == 0;
        //}

        //public void AssertDisplayedMessage(IWebElement message)
        //{
        //    Assert.IsTrue(message.Displayed);
        //}


    }
}
