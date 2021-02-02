using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using QA.Upskill.Program.Tests.PageObjects.UltimateQA;
using TechTalk.SpecFlow;

namespace QA.Upskill.Program.Tests.StepDefinitions
{
    [Binding]
    public class ToggleTestSteps : BaseTest
    {
        readonly ComplicatedPage _complicatedPage;

        public ToggleTestSteps(IWebDriver driver, ComplicatedPage complicatedPage) : base(driver)
        {
            _complicatedPage = complicatedPage;
        }

        [When(@"the page is scrolled down to the toggle")]
        public void WhenThePageIsScrolledDownToTheToggle()
        {
            Driver.ScrollToElement(_complicatedPage.DivLoginForm);
        }

        [When(@"the toggle is clicked")]
        public void WhenTheToggleIsClicked()
        {
            _complicatedPage.Toggle.Click();
        }

        [Then(@"the toggle is expanded and its inner text is shown")]
        public void ThenTheToggleIsExpandedAndItsInnerTextIsShown()
        {
            Assert.IsTrue(_complicatedPage.ToggleIsDisplayed);
            Assert.AreEqual("Inside of toggle", _complicatedPage.ToggleText);
        }

        [Then(@"the toggle is collapsed and its inner text is hidden")]
        public void ThenTheToggleIsCollapsedAndItsInnerTextIsHidden()
        {
            Assert.IsTrue(_complicatedPage.ToggleContentIsHidden);
        }
    }
}
