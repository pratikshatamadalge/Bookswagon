using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using BookswagonAutomation.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using RazorEngine.Compilation.ImpromptuInterface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Mail;
using System.Text;

namespace BookswagonAutomation.Base
{
    class TestCases:BaseClass
    {
        const string Path = "F:\\VS\\BookswagonAutomation\\BookswagonAutomation\\TestScreenshot\\";
       
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

        [Test, Order(1)]
        public void LoginTest()
        {
            try {
                ExtentTest loginTest = extent.CreateTest("LoginTest").Info("Login Test Started");
                Login login = new Login(driver);
                login.LoginPage();
                string actualTitle=driver.Title;
                Assert.AreEqual(actualTitle, "Online BookStore India, Buy Books Online, Buy Book Online Ind..");
                ((ITakesScreenshot)driver).GetScreenshot().SaveAsFile(Path+"Login.png", ScreenshotImageFormat.Png);
                log.Info("Login Test executed Successfully");
                ((ITakesScreenshot)driver).GetScreenshot().SaveAsFile(Path+"PurchaseBook.png", ScreenshotImageFormat.Png);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        }

        [Test, Order(2)]
        public void SearchBookTest()
        {
            ExtentTest searchBookTest = extent.CreateTest("SearchBookTest").Info("Search Book Test Started");
            SearchBook search = new SearchBook(driver);
            search.SearchBookPage();
            ((ITakesScreenshot)driver).GetScreenshot().SaveAsFile(Path + "Search.png", ScreenshotImageFormat.Png);
            log.Info("Search Book Test Executed Successfully");
        }

        [Test, Order(3)]
        public void ShoppingCartTest()
        {
            ExtentTest shoppingCartTest = extent.CreateTest("ShoppingCartTest").Info("Purchase Book Test started");
            ShoppingCart cart = new ShoppingCart(driver);
            cart.CartPage();
            ((ITakesScreenshot)driver).GetScreenshot().SaveAsFile(Path + "ShoppingCart.png", ScreenshotImageFormat.Png);
            log.Info("Shopping Cart Test executed successfully");
        }

        [Test, Order(4)]
        public void CheckoutLoginTest()
        {
            ExtentTest checkoutLoginTest = extent.CreateTest("CheckoutLoginTest").Info("Checkout Login Test started");
            CheckoutLogin checkout = new CheckoutLogin(driver);
            checkout.CheckoutLoginPage();
            ((ITakesScreenshot)driver).GetScreenshot().SaveAsFile(Path + "CheckoutLogin.png", ScreenshotImageFormat.Png);
            log.Info("Checkout Login Test Executed successfully");
        }

        [Test, Order(5)]
        public void ShippingAddressTest()
        {
            ExtentTest shippingAddressTest = extent.CreateTest("ShippingAddressTest").Info("Shipping Address Test started");
            ShippingAddress address = new ShippingAddress(driver);
            address.ShippingAddressPage();
            ((ITakesScreenshot)driver).GetScreenshot().SaveAsFile(Path + "ShippingAddress.png", ScreenshotImageFormat.Png);
            log.Info("Shipping Address Test Executed Successfully");
        }

        [Test, Order(6)]
        public void ViewShoppingCartTest()
        {
            ExtentTest viewShoppingCartTest = extent.CreateTest("ViewShoppingCartTest").Info("View shopping cart Test started");
            ViewShoppingCart view = new ViewShoppingCart(driver);
            view.ViewShoppingCartPage();
            ((ITakesScreenshot)driver).GetScreenshot().SaveAsFile(Path + "ViewShoppingCartPage.png", ScreenshotImageFormat.Png);
            log.Info("View Shopping Cart Test Executed Successfully");
        }

        [Test, Order(7)]
        public void LogoutTest()
        {
            ExtentTest logoutTest = extent.CreateTest("LogoutTest").Info("Logout Test started");
            Logout logout = new Logout(driver);
            logout.LogoutPage();
            ((ITakesScreenshot)driver).GetScreenshot().SaveAsFile(Path+"Logout.png", ScreenshotImageFormat.Png);
            log.Info("Logout Test Executed Successfully");
        }

        [OneTimeTearDown]
        public void ExtentClose()
        {
            extent.Flush();
        }
    }
}