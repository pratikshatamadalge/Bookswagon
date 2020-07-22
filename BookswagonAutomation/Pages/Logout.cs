using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookswagonAutomation.Pages
{
    class Logout
    {
        IWebDriver driver;
        public Logout(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "checkout-top")]
        IWebElement header;

        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Logout')]")]
        IWebElement logoutBtn;

        public void LogoutPage()
        {
            logoutBtn.Click();
        }
    }
}
