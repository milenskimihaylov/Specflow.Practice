using System;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace QA.Upskill.Program.Tests.PageObjects.UltimateQA
{
    public class ButtonSuccessPage : BasePage
    {
        public ButtonSuccessPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = "h1.entry-title")]
        public IWebElement ButtonSuccessHeader { get; set; }
        public By HeaderLocator => By.CssSelector("h1.entry-title");

        [FindsBy(How = How.CssSelector, Using = "img.lazyloaded")]
        public IWebElement Image { get; set; }
        public By ImageLocator => By.CssSelector("img.lazyloaded");

    }
}
