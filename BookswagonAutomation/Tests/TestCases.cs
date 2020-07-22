using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using BookswagonAutomation.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Net.Mail;
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

                ExtentTest test2 = extent.CreateTest("ShoppingCartTest").Info("Purchase Book Test started");
                ShoppingCart cart = new ShoppingCart(driver);
                cart.CartPage();
                log.Info("Shopping Cart Test executed successfully");

                ExtentTest test3 = extent.CreateTest("CheckoutLoginTest").Info("Checkout Login Test started");
                CheckoutLogin checkout = new CheckoutLogin(driver);
                checkout.CheckoutLoginPage();
                log.Info("Checkout Login Test Executed successfully");

                ExtentTest test4 = extent.CreateTest("ShippingAddressTest").Info("Shipping Address Test started");
                ShippingAddress address = new ShippingAddress(driver);
                address.ShippingAddressPage();
                log.Info("Shipping Address Test Executed Successfully");

                ExtentTest test5 = extent.CreateTest("ViewShoppingCartTest").Info("View shopping cart Test started");
                ViewShoppingCart view = new ViewShoppingCart(driver);
                view.ViewShoppingCartPage();
                log.Info("View Shopping Cart Test Executed Successfully");

                ExtentTest test6 = extent.CreateTest("LogoutTest").Info("Logout Test started");
                Logout logout = new Logout(driver);
                logout.LogoutPage();
                log.Info("Logout Test Executed Successfully");

                ((ITakesScreenshot)driver).GetScreenshot().SaveAsFile("F:\\VS\\BookswagonAutomation\\BookswagonAutomation\\TestScreenshot\\PurchaseBook.png", ScreenshotImageFormat.Png);

                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.live.com");
                mail.From = new MailAddress("pratikshatamadalge@outlook.com");
                mail.To.Add("pratikshatamadalge@gmail.com");
                mail.Subject = "Test Mail....";
                mail.Body = "Mail With Attachment";


                System.Net.Mail.Attachment attachment;
                attachment = new System.Net.Mail.Attachment("F:\\VS\\BookswagonAutomation\\ExtentReports\\index.html");
                mail.Attachments.Add(attachment);

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("pratikshatamadalge@outlook.com", "Pratiksha21@");
                SmtpServer.EnableSsl = true;
                SmtpServer.Send(mail);
            }
            catch (Exception e)
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
