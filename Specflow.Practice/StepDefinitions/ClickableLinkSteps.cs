using System;
using NUnit.Framework;
using TechTalk.SpecFlow;
using QA.Upskill.Program.Tests.PageObjects.UltimateQA;

namespace QA.Upskill.Program.Tests.StepDefinitions
{
    [Binding]
    public class ClickableLinkSteps
    {
        readonly ElementsForAutomationPage _elementsForAutomationPage;

        public ClickableLinkSteps(ElementsForAutomationPage elementsForAutomationPage)
        {
            _elementsForAutomationPage = elementsForAutomationPage;
        }

        [Then(@"Verify the link is clickable")]
        public void ThenVerifyTheLinkIsClickable()
        {
            Assert.IsTrue(_elementsForAutomationPage.IsLinkClickable());
        }

        [Then(@"the link is clicked")]
        public void ThenTheLinkIsClicked()
        {
            _elementsForAutomationPage.Link.Click();
        }
    }
}
