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
        ExtentReports extent= null;

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
            ExtentTest test = extent.CreateTest("LoginTest");
            Login login = new Login(driver);
            login.LoginPage();

            ExtentTest test1 = extent.CreateTest("SearchBookTest");
            SearchBook search = new SearchBook(driver);
            search.SearchBookPage();

            ExtentTest test2 = extent.CreateTest("PurchaseBookTest");
            Cart cart = new Cart(driver);
            cart.CartPage();

            ((ITakesScreenshot)driver).GetScreenshot().SaveAsFile("F:\\VS\\BookswagonAutomation\\BookswagonAutomation\\TestScreenshot\\PurchaseBook.png", ScreenshotImageFormat.Png);
        }

        [OneTimeTearDown]
        public void ExtentClose()
        {
            extent.Flush();
        }
    }
}
