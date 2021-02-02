using System;

using TechTalk.SpecFlow;
using QA.Upskill.Program.Tests.PageObjects.UltimateQA;
using OpenQA.Selenium;
using NUnit.Framework;

namespace QA.Upskill.Program.Tests.StepDefinitions
{
    [Binding]
    public class ButtonClickSteps : BaseTest
    {
        readonly ComplicatedPage _complicatedPage;
        readonly ElementsForAutomationPage _elementsForAutomationPage;
        readonly ButtonSuccessPage _buttonSuccessPage;
        readonly LinkSuccessPage _linkSuccessPage;

        public ButtonClickSteps(IWebDriver driver, ComplicatedPage complicatedPage, ElementsForAutomationPage elementsForAutomationPage, ButtonSuccessPage buttonSuccessPage, LinkSuccessPage linkSuccessPage)
            :base(driver)
        {
            _complicatedPage = complicatedPage;
            _elementsForAutomationPage = elementsForAutomationPage;
            _buttonSuccessPage = buttonSuccessPage;
            _linkSuccessPage = linkSuccessPage;
        }

        [Then(@"(.*) button\(s\) on the page are clicked")]
        public void ThenButtonSOnThePageAreClicked(int buttonsNumber)
        {
            _complicatedPage.ButtonClick(buttonsNumber);
        }

        [When(@"the page is scrolled down to Simple Controls section")]
        public void WhenThePageIsScrolledDownToSimpleControlsSection()
        {
            Driver.ScrollToElement(_elementsForAutomationPage.SimpleControlsSection);
        }

        [When(@"Click Me button on the page is clicked")]
        public void WhenClickMeButtonOnThePageIsClicked()
        {
            _elementsForAutomationPage.ClickMeButton.Click();
        }

        [Then(@"correct header ""(.*)"" is present on the page")]
        public void ThenCorrectHeaderIsPresentOnThePage(string header)
        {
            if (header == "Button success")
            {
                Driver.WaitElementToExists(_buttonSuccessPage.HeaderLocator);

                Assert.IsTrue(_buttonSuccessPage.ButtonSuccessHeader.Displayed);
                Assert.AreEqual(header, _buttonSuccessPage.ButtonSuccessHeader.Text);
            }
            else if (header == "Link success")
            {
                Driver.WaitElementToExists(_linkSuccessPage.HeaderLocator);

                Assert.IsTrue(_linkSuccessPage.LinkSuccessHeader.Displayed);
                Assert.AreEqual(header, _linkSuccessPage.LinkSuccessHeader.Text);
            }
        }

        [Then(@"image ""(.*)"" is loaded on the page")]
        public void ThenImageIsLoadedOnThePage(string image)
        {
            if (image == "Button success image")
            {
                Driver.WaitElementToExists(_buttonSuccessPage.ImageLocator);

                Assert.IsTrue(_buttonSuccessPage.Image.Displayed);
            }
            else if (image == "Link success image")
            {
                Driver.WaitElementToExists(_linkSuccessPage.ImageLocator);

                Assert.IsTrue(_linkSuccessPage.Image.Displayed);
            }
        }
    }
}
