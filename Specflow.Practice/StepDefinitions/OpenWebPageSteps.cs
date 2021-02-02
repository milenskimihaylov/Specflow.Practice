using System;
using NUnit.Framework;
using QA.Upskill.Program.Tests.PageObjects.UltimateQA;
using TechTalk.SpecFlow;

namespace QA.Upskill.Program.Tests.StepDefinitions
{
    [Binding]
    public class OpenWebPageSteps
    {
        readonly LandingPage _landingPage;

        public OpenWebPageSteps(LandingPage landingPage)
        {
            _landingPage = landingPage;
        }

        [When(@"correct URL (.*) is entered in the browser")]
        [Given(@"correct URL (.*) is entered in the browser")]
        public void WhenCorrectURLIsEnteredInTheBrowser(string URL)
        {
            _landingPage.OpenWebPage(URL);
        }

        [Then(@"the desired web page is opened correctly")]
        public void ThenTheDesiredWebPageIsOpenedCorrectly()
        {
            Assert.IsTrue(_landingPage.LaptopImage.Displayed, "Check if the slowest image on the page is displayed.");
            _landingPage.AssertWebPageURL();
            _landingPage.AssertWebPageTitle();
        }
    }
}
