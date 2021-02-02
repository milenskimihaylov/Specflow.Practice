using System;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QA.Upskill.Program.Tests.PageObjects.UltimateQA
{
    public class PricingPage : BasePage
    {
        public PricingPage(IWebDriver driver) : base(driver)
        {
        }

        public string URL => Driver.Url;

        public string Title => Driver.Title;

        public IWebElement PricingTable(int tableNumber) => Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector($"div.et_pb_pricing_table_{tableNumber}")));

        public List<IWebElement> Price => Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.CssSelector("span.et_pb_sum"))).ToList();

        //public List<IWebElement> Slash => Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.CssSelector(".et_pb_frequency_slash"))).ToList();

        public List<IWebElement> Month => Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.CssSelector("span.et_pb_frequency"))).ToList();

        public string Concatenator(string text1, string text2)
        {

            var concatenatedText = text1 + text2; 
            
            return concatenatedText;
        }

        public void VerifyPrices(string expectedPrice, string actualPrice)
        {
            Assert.AreEqual(expectedPrice, actualPrice);
        }
    }
}
