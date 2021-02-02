using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using OpenQA.Selenium;

namespace QA.Upskill.Program.Tests.PageObjects.UltimateQA
{
    public class LandingPage : BasePage
    {
        public LandingPage(IWebDriver driver) : base(driver)
        {
        }

        public string URL => Driver.Url;

        public string Title => Driver.Title;

        public List<IWebElement> CoursesIcons => Wait.Until(d => d.FindElements(By.CssSelector("a .et_pb_image_wrap"))).ToList();

        public IWebElement ViewCoursesButton => Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.CssSelector("a.et_pb_button_0")));

        public IWebElement Courses => Wait.Until(d => d.FindElement(By.XPath("//ul[@id='top-menu']//a[text()='Courses']")));

        public IWebElement SeleniumResources => Wait.Until(d => d.FindElement(By.XPath("//ul[@id='top-menu']//a[text()='Selenium Resources']")));

        public IWebElement AutomationExercises => Wait.Until(d => d.FindElement(By.XPath("//ul[@id='top-menu']//a[text()='Automation Exercises']")));

        public IWebElement Podcast => Wait.Until(d => d.FindElement(By.XPath("//ul[@id='top-menu']//a[text()='Podcast']")));

        public IWebElement Blog => Wait.Until(d => d.FindElement(By.XPath("//ul[@id='top-menu']//a[text()='Blog']")));

        public IWebElement LaptopImage => Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector(".et_pb_image_0 .et_pb_image_wrap > img")));

        public void OpenWebPage(string URL)
        {
            Driver.Navigate().GoToUrl(URL);
        }

        public void AssertWebPageTitle()
        {
            Assert.AreEqual("Fake landing page - Ultimate QA", Title);
        }

        public void AssertWebPageURL()
        {
            Assert.AreEqual("https://ultimateqa.com/fake-landing-page/", URL);
        }
    }
}
