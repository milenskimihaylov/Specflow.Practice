using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace QA.Upskill.Program.Tests
{
    public static class DriverExtensions
    {
        public static void ScrollToPixels(this IWebDriver driver, int pixels)
        {
            ((IJavaScriptExecutor)driver).ExecuteScript($"window.scrollBy(0, {pixels})");
        }

        public static IWebElement ScrollToElement(this IWebDriver driver, IWebElement element)
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
            return element;
        }

        public static IWebElement WaitElementToExists(this IWebDriver driver, By by)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(by));
        }
    }
}
