using BookswagonAutomation.Data;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace BookswagonAutomation.Pages
{
    class Login:JsonReader
    {
        public IWebDriver driver;

        public Login(IWebDriver driver)
        {
          this.driver = driver;
          PageFactory.InitElements(driver,this);
        }

        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Login')]")]
        public IWebElement LoginLink;

        [FindsBy(How = How.Id, Using = "ctl00_phBody_SignIn_txtEmail")]
        public IWebElement EmailTextBox;

        [FindsBy(How = How.Id, Using = "ctl00_phBody_SignIn_txtPassword")]
        public IWebElement PasswordTextBox;

        [FindsBy(How = How.Id, Using = "ctl00_phBody_SignIn_btnLogin")]
        public IWebElement LoginBtn;

        public void LoginPage()
        {
            JsonReader reader = new JsonReader();
            LoginLink.Click();
            Thread.Sleep(2000);
            EmailTextBox.SendKeys(reader.email);
            PasswordTextBox.SendKeys(reader.password);
            LoginBtn.Click();
            Thread.Sleep(1000);
        }
    }
}
