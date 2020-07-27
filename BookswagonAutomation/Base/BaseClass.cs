using Microsoft.AspNetCore.Http.Features;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;
using System.Net.Mail;

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

        [OneTimeTearDown]
        public void Close()
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.live.com");
                mail.From = new MailAddress("pratikshatamadalge@gmail.com");
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
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
            driver.Quit();
        }
    }
}