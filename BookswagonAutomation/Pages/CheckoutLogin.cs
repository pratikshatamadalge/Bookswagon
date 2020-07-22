using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

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

        [FindsBy(How = How.ClassName, Using = "btn-red")]
        IWebElement continueBtn;

        public void CheckoutLoginPage()
        {
            continueBtn.Click();
        }
    }
}
