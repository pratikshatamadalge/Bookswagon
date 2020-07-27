using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace BookswagonAutomation.Pages
{
    class CheckoutLogin
    {
        public IWebDriver driver;

        public CheckoutLogin(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//a[@class='btn-red']")]
        IWebElement continueBtn;

        public void CheckoutLoginPage()
        {
            Thread.Sleep(2000);
            continueBtn.Click();
        }
    }
}