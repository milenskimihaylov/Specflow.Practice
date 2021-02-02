using System;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using QA.Upskill.Program.Tests.PageObjects.UltimateQA;
using NUnit.Framework;

namespace QA.Upskill.Program.Tests.StepDefinitions
{
    [Binding]
    public class SelectFromDropdownSteps : BaseTest
    {
        readonly ElementsForAutomationPage _elementsForAutomationPage;

        public SelectFromDropdownSteps(IWebDriver driver, ElementsForAutomationPage elementsForAutomationPage) : base(driver)
        {
            _elementsForAutomationPage = elementsForAutomationPage;
        }

        [When(@"the page is scrolled down to the Dropdown")]
        public void WhenThePageIsScrolledDownToTheDropdown()
        {
            Driver.ScrollToElement(_elementsForAutomationPage.DropdownHeader);
        }

        [When(@"an option (.*) from the dropdown is selected")]
        public void WhenAnOptionOpelFromTheDropdownIsSelected(string option)
        {
            _elementsForAutomationPage.SelectElementFromList(_elementsForAutomationPage.Dropdown, option);
        }

        [Then(@"Verify the correct option (.*) is selected")]
        public void ThenVerifyTheCorrectOptionOpelIsSelected(string option)
        {
            Assert.AreEqual(option, _elementsForAutomationPage.Dropdown.GetProperty("value"));
        }
    }
}
