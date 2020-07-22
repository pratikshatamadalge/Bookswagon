using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using BookswagonAutomation.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookswagonAutomation.Base
{
    class TestCases:BaseClass
    {
        //applied logger in console
        private static readonly log4net.ILog log =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


        ExtentReports extent = null;

        [OneTimeSetUp]
        public void ExtentStart()
        {
            extent = new ExtentReports();
            var htmlReporter = new ExtentHtmlReporter(@"F:\\VS\\BookswagonAutomation\\BookswagonAutomation\\ExtentReports\\Report.html");
            extent.AttachReporter(htmlReporter);
        }

        [Test]
        public void BookswagonAutomationTest()
        {
            try {
                ExtentTest test = extent.CreateTest("LoginTest").Info("Login Test Started");
                Login login = new Login(driver);
                login.LoginPage();
                ((ITakesScreenshot)driver).GetScreenshot().SaveAsFile("F:\\VS\\BookswagonAutomation\\BookswagonAutomation\\TestScreenshot\\Login.png", ScreenshotImageFormat.Png);
                log.Info("Login Test executed Successfully");

                ExtentTest test1 = extent.CreateTest("SearchBookTest").Info("Search Book Test Started");
                SearchBook search = new SearchBook(driver);
                search.SearchBookPage();
                ((ITakesScreenshot)driver).GetScreenshot().SaveAsFile("F:\\VS\\BookswagonAutomation\\BookswagonAutomation\\TestScreenshot\\Search.png", ScreenshotImageFormat.Png);
                log.Info("Search Book Test Executed Successfully");

                ExtentTest test2 = extent.CreateTest("PurchaseBookTest").Info("Purchase Book Test started");
                Cart cart = new Cart(driver);
                cart.CartPage();
                log.Info("Book purchase test Executed successfully");

                ((ITakesScreenshot)driver).GetScreenshot().SaveAsFile("F:\\VS\\BookswagonAutomation\\BookswagonAutomation\\TestScreenshot\\PurchaseBook.png", ScreenshotImageFormat.Png);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            }
        [OneTimeTearDown]
        public void ExtentClose()
        {
            extent.Flush();
        }
    }
}
