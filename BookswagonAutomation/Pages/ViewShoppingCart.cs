using BookswagonAutomation.Data;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookswagonAutomation.Pages
{
    class ViewShoppingCart
    {
        IWebDriver driver;
        public ViewShoppingCart(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "ctl00_cpBody_ShoppingCart_lvCart_txtGiftMessage")]
        IWebElement giftMessage;

        [FindsBy(How = How.Id, Using = "ctl00_cpBody_ShoppingCart_lvCart_savecontinue")]
        IWebElement saveAndContinueBtn1;

        public void ViewShoppingCartPage()
        {
            JsonReader reader = new JsonReader();
            giftMessage.SendKeys(reader.giftmessage);
            saveAndContinueBtn1.Click();
        }
    }
}
