using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace QA.Upskill.Program.Tests.PageObjects.UltimateQA
{
    public class ElementsForAutomationPage : BasePage
    {
        public ElementsForAutomationPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = ".et_pb_cta_0 .et_pb_button")]
        public IWebElement ClickMeButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[text()='Simple Controls']")]
        public IWebElement SimpleControlsSection { get; set; }

        [FindsBy(How = How.CssSelector, Using = "a#simpleElementsLink")]
        public IWebElement Link { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[text()='Dropdown']")]
        public IWebElement DropdownHeader { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".et_pb_blurb_description > select")]
        public IWebElement Dropdown { get; set; }

        [FindsBy(How = How.XPath, Using = "//h2[text()='HTML Table with unique id']")]
        public IWebElement TableWithIdHeader { get; set; }

        [FindsBy(How = How.Id, Using = "htmlTableId")]
        public IWebElement TableWithId { get; set; }

        [FindsBy(How = How.XPath, Using = "//table[@id = 'htmlTableId']//tr")]
        public IList<IWebElement> TableRows { get; set; }

        [FindsBy(How = How.XPath, Using = "//table[@id = 'htmlTableId']//tr/th")]
        public IList<IWebElement> TableHeaders { get; set; }

        [FindsBy(How = How.XPath, Using = "//table[@id = 'htmlTableId']//tr/td")]
        public IList<IWebElement> TableCells { get; set; }

        public bool IsLinkClickable()
        {
            if (Link.Displayed && Link.Enabled)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
