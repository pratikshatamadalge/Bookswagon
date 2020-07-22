using Microsoft.AspNetCore.Http.Features;
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
            try
            {
                //Pre requisits to open chrome .
                ChromeOptions options = new ChromeOptions();
                options.AddArguments("start-maximized");
                options.AddArguments("-incognito");

                //Launch the chrome browser
                driver = new ChromeDriver(options);
                
                //Using implicitly wait 
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

                //Maximizing the window
               // driver.Manage().Window.Maximize();

                driver.Url = "https://www.bookswagon.com";

                ((ITakesScreenshot)driver).GetScreenshot().SaveAsFile("F:\\VS\\BookswagonAutomation\\BookswagonAutomation\\TestScreenshot\\Test.png", ScreenshotImageFormat.Png);
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        [TearDown]
        public void Close()
        {
            driver.Quit();
        }
    }
}