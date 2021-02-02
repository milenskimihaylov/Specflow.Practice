using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace QA.Upskill.Program.Tests.PageObjects
{
    public class BasePage
    {
        protected IWebDriver Driver { get; set; }

        protected WebDriverWait Wait => new WebDriverWait(Driver, TimeSpan.FromSeconds(30));

        protected Actions Builder => new Actions(Driver);

        protected SelectElement Select { get; set; }

        public BasePage(IWebDriver driver)
        {
            Driver = driver;
        }

        public void SelectElementFromList(IWebElement element, string option)
        {
            Builder.MoveToElement(element).Click();
            Select = new SelectElement(element);
            Select.SelectByValue(option);
        }
    }
}
