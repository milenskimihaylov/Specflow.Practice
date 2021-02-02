using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace QA.Upskill.Program.Tests
{
    public static class WebElementExtensions
    {
        public static void FillIn(this IWebElement webElement, string text)
        {
            webElement.Clear();
            webElement.SendKeys(text);
        }
    }
}
