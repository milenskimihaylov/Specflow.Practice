using System;
using System.IO;
using System.Reflection;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace QA.Upskill.Program.Tests
{
    public class BaseTest
    {
        protected IWebDriver Driver { get; private set; }

        public BaseTest(IWebDriver driver)
        {
            Driver = driver;
        }

        public void Initialize()
        {
            Driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            Driver.Manage().Window.Maximize();
        }

        public void TearDown()
        {
            Driver.Quit();
        }
    }

}
