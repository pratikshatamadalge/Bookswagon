using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;

namespace BookswagonAutomation
{
    public class BaseClass
    {
        public IWebDriver driver;
        [OneTimeSetUp]
        public void Setup()
        {
            //using chrome options to disable unwanted notifications
            ChromeOptions opt = new ChromeOptions();
            opt.AddArguments("--disable-notifications");

            //Launch the chrome browser
            driver = new ChromeDriver();

            //Using implicitly wait 
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

            //Maximizing the window
            driver.Manage().Window.Maximize();

            driver.Url = "https://www.bookswagon.com";
        }

        [TearDown]
        public void Close()
        {
            driver.Quit();
        }
    }
}