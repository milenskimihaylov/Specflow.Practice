using System;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using QA.Upskill.Program.Tests.PageObjects.UltimateQA;
using NUnit.Framework;
using System.Threading;

namespace QA.Upskill.Program.Tests.StepDefinitions
{
    [Binding]
    public class ValidateTableContentsSteps : BaseTest
    {
        readonly ElementsForAutomationPage _elementsForAutomationPage;

        public ValidateTableContentsSteps(IWebDriver driver, ElementsForAutomationPage elementsForAutomationPage) : base(driver)
        {
            _elementsForAutomationPage = elementsForAutomationPage;
        }

        [When(@"the page is scrolled down to the table")]
        public void WhenThePageIsScrolledDownToTheTable()
        {
            Driver.ScrollToElement(_elementsForAutomationPage.TableWithIdHeader);
        }

        [Then(@"Verify the table contents")]
        public void ThenVerifyTheTableContents()
        {
            Assert.AreEqual("Title", _elementsForAutomationPage.TableHeaders[0].Text);
            Assert.AreEqual("Work", _elementsForAutomationPage.TableHeaders[1].Text);
            Assert.AreEqual("Salary", _elementsForAutomationPage.TableHeaders[2].Text);

            Assert.AreEqual("Software Development Engineer in Test", _elementsForAutomationPage.TableCells[0].Text);
            Assert.AreEqual("Automation", _elementsForAutomationPage.TableCells[1].Text);
            Assert.AreEqual("$150,000+", _elementsForAutomationPage.TableCells[2].Text);
            Assert.AreEqual("Automation Testing Architect", _elementsForAutomationPage.TableCells[3].Text);
            Assert.AreEqual("Automation", _elementsForAutomationPage.TableCells[4].Text);
            Assert.AreEqual("$120,000+", _elementsForAutomationPage.TableCells[5].Text);
            Assert.AreEqual("Quality Assurance Engineer", _elementsForAutomationPage.TableCells[6].Text);
            Assert.AreEqual("Manual", _elementsForAutomationPage.TableCells[7].Text);
            Assert.AreEqual("$50,000+", _elementsForAutomationPage.TableCells[8].Text);
        }
    }
}
