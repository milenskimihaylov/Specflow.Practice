using System;

using TechTalk.SpecFlow;
using QA.Upskill.Program.Tests.PageObjects.UltimateQA;

namespace QA.Upskill.Program.Tests.StepDefinitions
{
    [Binding]
    public class VerifyOffersPricesSteps
    {
        readonly PricingPage _pricingPage;

        public VerifyOffersPricesSteps(PricingPage pricingPage)
        {
            _pricingPage = pricingPage;
        }

        [Then(@"verify that the offers prices are correct (.*) (.*) (.*)")]
        public void ThenVerifyThatTheOffersPricesAreCorrect(string expectedPrice1, string expectedPrice2, string expectedPrice3)
        {
            var actualPrice1 = _pricingPage.Concatenator(_pricingPage.Price[0].Text, _pricingPage.Month[0].Text);
            var actualPrice2 = _pricingPage.Concatenator(_pricingPage.Price[1].Text, _pricingPage.Month[1].Text);
            var actualPrice3 = _pricingPage.Concatenator(_pricingPage.Price[2].Text, _pricingPage.Month[2].Text);
            
            _pricingPage.VerifyPrices(expectedPrice1, actualPrice1);
            _pricingPage.VerifyPrices(expectedPrice2, actualPrice2);
            _pricingPage.VerifyPrices(expectedPrice3, actualPrice3);
        }
    }
}
