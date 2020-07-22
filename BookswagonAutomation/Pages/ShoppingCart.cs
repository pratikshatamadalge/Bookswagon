using BookswagonAutomation.Data;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace BookswagonAutomation.Pages
{
    class ShoppingCart
    {
        public IWebDriver driver;

        public ShoppingCart(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//iframe[@class='cboxIframe']")]
        public IWebElement placeOrderFrame;

        [FindsBy(How = How.Id, Using = "BookCart_lvCart_imgPayment")]
        public IWebElement placeorder;

        

        public void CartPage()
        {
            JsonReader reader = new JsonReader();
            driver.SwitchTo().Frame(placeOrderFrame);
            placeorder.Click();
            Thread.Sleep(1000);

            //driver.SwitchTo().Frame(header);
            //logoutBtn.Click();
            Thread.Sleep(2000);
        }
    }
}
